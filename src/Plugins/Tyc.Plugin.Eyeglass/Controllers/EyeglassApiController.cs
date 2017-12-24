using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Core;
using Nop.Services.Media;
using Nop.Web.Framework.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Models.Lenses;
using Tyc.Plugin.Eyeglass.Services.Lenses;
using Tyc.Plugin.Eyeglass.Services.Tryon;

namespace Tyc.Plugin.Eyeglass.Controllers
{
    public class EyeglassApiController : BaseEyeglassController
    {
        private readonly IGlassService _glassService;
        private readonly ITryonService _tryonService;


        public EyeglassApiController(IGlassService glassService, ITryonService tryonService)
        {
            this._glassService = glassService;
            this._tryonService = tryonService;
        }
        // API: Plugins/TycApi/EyeglassApi/AllGlassType
        public IActionResult AllGlassType()
        {
            return this.JsonOk(new { name = "tianyingchun" });
        }

        [Route("Plugins/TycApi/EyeglassApi/GetAllGlassLenses")]
        public IActionResult GetAllGlassLenses()
        {
            var allGlassLenses = _glassService.GetAllGlassLenses();
            var result = new List<GlassLensesModel>();
            foreach (var item in allGlassLenses)
            {
                var model = new GlassLensesModel
                {
                    Name = item.Name,
                    GlassType = item.GlassType,
                    DisplayOrder = item.DisplayOrder,
                    HelpDescription = item.HelpDescription,
                    ShortDescription = item.ShortDescription
                };
                result.Add(model);
            }

            return this.JsonOk(result);
        }

        [Route("Plugins/TycApi/EyeglassApi/UploadTryonCroppedPicture")]
        [HttpPost]
        //do not validate request token (XSRF)
        [AdminAntiForgery(true)]
        public virtual IActionResult UploadTryonCroppedPicture(int productId, int x, int y, int x2, int y2)
        {

            var httpPostedFile = Request.Form.Files.FirstOrDefault();
            if (httpPostedFile == null)
            {
                return Json(new
                {
                    code = "0001",
                    message = "No file uploaded",
                    data = ""
                });
            }

            var fileBinary = httpPostedFile.GetDownloadBits();

            var qqFileNameParameter = "tryonCrop";
            var fileName = httpPostedFile.FileName;
            if (string.IsNullOrEmpty(fileName) && Request.Form.ContainsKey(qqFileNameParameter))
                fileName = Request.Form[qqFileNameParameter].ToString();
            //remove path (passed in IE)
            fileName = Path.GetFileName(fileName);

            var contentType = httpPostedFile.ContentType;

            var fileExtension = Path.GetExtension(fileName);
            if (!string.IsNullOrEmpty(fileExtension))
                fileExtension = fileExtension.ToLowerInvariant();

            //contentType is not always available 
            //that's why we manually update it here
            //http://www.sfsu.edu/training/mimetype.htm
            if (string.IsNullOrEmpty(contentType))
            {
                switch (fileExtension)
                {
                    case ".bmp":
                        contentType = MimeTypes.ImageBmp;
                        break;
                    case ".gif":
                        contentType = MimeTypes.ImageGif;
                        break;
                    case ".jpeg":
                    case ".jpg":
                    case ".jpe":
                    case ".jfif":
                    case ".pjpeg":
                    case ".pjp":
                        contentType = MimeTypes.ImageJpeg;
                        break;
                    case ".png":
                        contentType = MimeTypes.ImagePng;
                        break;
                    case ".tiff":
                    case ".tif":
                        contentType = MimeTypes.ImageTiff;
                        break;
                    default:
                        break;
                }
            }

            string croppedUrl = _tryonService.UploadTryonCroppedPicture(fileBinary, productId, contentType, x, y, x2, y2);

            //when returning JSON the mime-type must be set to text/plain
            //otherwise some browsers will pop-up a "Save As" dialog.
            return Json(new
            {
                code = "0000",
                message = "",
                data = new
                {
                    productId,
                    croppedUrl
                }
            });
        }
    }
}
