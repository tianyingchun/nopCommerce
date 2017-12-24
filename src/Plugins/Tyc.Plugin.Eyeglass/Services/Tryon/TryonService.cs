using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Services.Events;
using Nop.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Tyc.Plugin.Eyeglass.Domain.Tryon;
using Tyc.Plugin.Eyeglass.Infrastructure.Cache;
using Nop.Core.Domain.Media;
using System.Drawing;
using System.IO;
using ImageResizer;
using Nop.Services.Media;
using Microsoft.AspNetCore.Hosting;
using System.Threading;
using Nop.Core;

namespace Tyc.Plugin.Eyeglass.Services.Tryon
{
    public partial class TryonService : ITryonService
    {
        #region Fields

        private readonly IRepository<GlassTryon> _glassTryonRepository;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly IPictureService _pictureService;
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IWebHelper _webHelper;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;


        #endregion

        #region Ctor

        public TryonService(
            IRepository<GlassTryon> glassTryonRepository,
            IPictureService pictureService,
            ICacheManager cacheManager,
            ILogger logger,
            IWebHelper webHelper,
            IHostingEnvironment hostingEnvironment,
            IStoreContext storeContext,
             IWorkContext workContext,
        IEventPublisher eventPublisher)
        {
            this._glassTryonRepository = glassTryonRepository;
            this._cacheManager = cacheManager;
            this._eventPublisher = eventPublisher;
            this._pictureService = pictureService;
            this._logger = logger;
            this._webHelper = webHelper;
            this._hostingEnvironment = hostingEnvironment;
            this._storeContext = storeContext;
            this._workContext = workContext;
        }

        #endregion

        #region Methods


        public IList<GlassTryon> GetAllTryon()
        {
            var query = from p in _glassTryonRepository.Table
                        orderby p.UpdatedOnUtc, p.CreatedOnUtc, p.Id
                        select p;

            return query.ToList();
        }

        public GlassTryon GetGlassTryonById(int glassTryonId)
        {
            if (glassTryonId == 0)
                return null;

            var key = string.Format(ModelCacheEventConsumer.GLASSTRYON_BY_ID_KEY, glassTryonId);
            return _cacheManager.Get(key, () => _glassTryonRepository.GetById(glassTryonId));
        }

        public IList<GlassTryon> GetTryonByCustomerId(int customerId = 0)
        {
            var key = string.Format(ModelCacheEventConsumer.GLASSTRYON_BY_CUSTOMERID_KEY, customerId);
            return _cacheManager.Get(key, () =>
            {
                var query = _glassTryonRepository.Table;
                if (customerId > 0)
                    query = query.Where(rph => rph.CustomerId == customerId);

                return query.OrderByDescending(p => p.UpdatedOnUtc).ToList();
            });
        }

        public void InsertTryon(GlassTryon glassTryon)
        {
            if (glassTryon == null)
                throw new ArgumentNullException(nameof(glassTryon));

            //insert
            _glassTryonRepository.Insert(glassTryon);

            //clear cache
            _cacheManager.RemoveByPattern(ModelCacheEventConsumer.GLASSTRYON_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityInserted(glassTryon);
        }

        public void UpdateTryon(GlassTryon glassTryon)
        {
            if (glassTryon == null)
                throw new ArgumentNullException(nameof(glassTryon));

            //update
            _glassTryonRepository.Update(glassTryon);

            //cache
            _cacheManager.RemoveByPattern(ModelCacheEventConsumer.GLASSTRYON_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityUpdated(glassTryon);
        }

        public void DeleteTryon(GlassTryon glassTryon)
        {
            if (glassTryon == null)
                throw new ArgumentNullException(nameof(glassTryon));

            //delete
            _glassTryonRepository.Delete(glassTryon);

            //clear cache
            _cacheManager.RemoveByPattern(ModelCacheEventConsumer.GLASSTRYON_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityDeleted(glassTryon);
        }


        public string UploadTryonCroppedPicture(byte[] pictureBinary, int productId, string mimeType, int x, int y, int x2, int y2)
        {

            //ImageBuilder.Current.Build(new ImageJob());
            var picture = _pictureService.InsertPicture(pictureBinary, mimeType, null);
            var lastPart = GetFileExtensionFromMimeType(picture.MimeType);

            byte[] pictureBinaryResized;
            string thumbFileName = $"{picture.Id:0000000}_x{x}_y{y}_x2{x2}_y2{y2}.{lastPart}";
            using (var mutex = new Mutex(false, thumbFileName))
            {
                using (var stream = new MemoryStream(pictureBinary))
                {
                    Bitmap b = null;
                    try
                    {
                        //try-catch to ensure that picture binary is really OK. Otherwise, we can get "Parameter is not valid" exception if binary is corrupted for some reasons
                        b = new Bitmap(stream);
                    }
                    catch (ArgumentException exc)
                    {
                        _logger.Error($"Tyc.Plugin.Eyeglass: Error generating picture thumb. ID={picture.Id}", exc);
                    }

                    using (var destStream = new MemoryStream())
                    {
                        ImageBuilder.Current.Build(b, destStream, new ResizeSettings
                        {
                            Mode = FitMode.Crop,
                            CropXUnits = b.Width,
                            CropYUnits = b.Height,
                            CropTopLeft = new PointF(x, y),
                            CropBottomRight = new PointF(x2, y2),
                            Scale = ScaleMode.Both
                        });
                        pictureBinaryResized = destStream.ToArray();
                        b.Dispose();
                    }
                }
                SaveThumb(thumbFileName, picture.MimeType, pictureBinaryResized);
            }
            var url = GetThumbUrl(thumbFileName);

            this.InsertTryon(new GlassTryon
            {
                ProductId = productId,
                CustomerId = _workContext.CurrentCustomer.Id,
                StoreId = _storeContext.CurrentStore.Id,
                Url = url
            });
            return url;
        }



        public GlassTryon SaveTryonModel(int productId, string leftX, string leftY, string rightX, string rightY, string pd)
        {
            var glassTryon = this.GetTryonByCustomerId(_workContext.CurrentCustomer.Id).Where(s => s.ProductId == productId && s.StoreId == _storeContext.CurrentStore.Id && string.IsNullOrEmpty(s.LeftX)).FirstOrDefault();

            if (glassTryon != null)
            {
                glassTryon.LeftX = leftX;
                glassTryon.LeftY = leftY;
                glassTryon.RightX = leftX;
                glassTryon.RightY = rightY;
                glassTryon.PD = pd;
                glassTryon.UpdatedOnUtc = DateTime.UtcNow;
                this.UpdateTryon(glassTryon);
            }
            else
            {
                _logger.Error($"Tyc.Plugin.Eyeglass: Error  SaveTryonModel. ProductID={productId}, CustomerId={_workContext.CurrentCustomer.Id}");
            }

            return glassTryon;
        }

        #endregion

        #region Helpers

        protected virtual string GetFileExtensionFromMimeType(string mimeType)
        {
            if (mimeType == null)
                return null;

            //TODO use FileExtensionContentTypeProvider to get file extension

            var parts = mimeType.Split('/');
            var lastPart = parts[parts.Length - 1];
            switch (lastPart)
            {
                case "pjpeg":
                    lastPart = "jpg";
                    break;
                case "x-png":
                    lastPart = "png";
                    break;
                case "x-icon":
                    lastPart = "ico";
                    break;
            }
            return lastPart;
        }

        protected virtual string GetThumbUrl(string thumbFileName, string storeLocation = null)
        {
            storeLocation = !string.IsNullOrEmpty(storeLocation)
                            ? storeLocation
                            : _webHelper.GetStoreLocation();
            var url = storeLocation + "images/tryon/";

            url = url + thumbFileName;
            return url;
        }
        protected virtual void SaveThumb(string thumbFileName, string mimeType, byte[] binary)
        {
            //ensure \thumb directory exists
            var thumbsDirectoryPath = Path.Combine(_hostingEnvironment.WebRootPath, "images\\tryon");
            var thumbFilePath = Path.Combine(thumbsDirectoryPath, thumbFileName);

            if (!System.IO.Directory.Exists(thumbsDirectoryPath))
                System.IO.Directory.CreateDirectory(thumbsDirectoryPath);


            //save
            File.WriteAllBytes(thumbFilePath, binary);
        }

        #endregion

    }
}
