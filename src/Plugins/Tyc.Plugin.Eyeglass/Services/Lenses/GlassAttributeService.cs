using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Domain;
using Tyc.Plugin.Eyeglass.Domain.Lenses;
using Tyc.Plugin.Eyeglass.Infrastructure.Cache;

namespace Tyc.Plugin.Eyeglass.Services.Lenses
{
    public class GlassAttributeService : IGlassAttributeService
    {
        #region Fields

        private readonly IRepository<GlassLensesAttribute> _glassLensesAttributeRepository;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region Ctor

        public GlassAttributeService(
            IRepository<GlassLensesAttribute> glassLensesAttributeRepository,
            ICacheManager cacheManager,
            IEventPublisher eventPublisher)
        {
            this._glassLensesAttributeRepository = glassLensesAttributeRepository;
            this._cacheManager = cacheManager;
            this._eventPublisher = eventPublisher;
        }

        #endregion

        public void DeleteGlassLensesAttribute(GlassLensesAttribute glassLensesAttribute)
        {
            if (glassLensesAttribute == null)
                throw new ArgumentNullException(nameof(glassLensesAttribute));

            //delete
            _glassLensesAttributeRepository.Delete(glassLensesAttribute);

            //clear cache
            _cacheManager.RemoveByPattern(ModelCacheEventConsumer.GLASSLENSESATTRIBUTE_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityDeleted(glassLensesAttribute);
        }

        public IList<GlassLensesAttribute> GetAllGlassLensesAttributes(int glassLensesId)
        {
            var key = string.Format(ModelCacheEventConsumer.GLASSLENSESATTRIBUTEBY_GLASSLENSES_ID_KEY, glassLensesId);

            return _cacheManager.Get(key, () =>
            {
                var query = from p in _glassLensesAttributeRepository.Table
                            where p.GlassLensesId == glassLensesId
                            orderby p.DisplayOrder, p.Id
                            select p;

                return query.ToList();
            });
        }

        public IList<GlassLensesAttribute> GetAllGlassLensesAttributes(int glassLensesId, GlassLensesAttributeType glassLensesAttributeType = GlassLensesAttributeType.LensThickness)
        {
            var result = this.GetAllGlassLensesAttributes(glassLensesId);
            return result.Where(
                     p => p.GlassLensesAttributeType == glassLensesAttributeType
                   )
                  .ToList();
        }


        public GlassLensesAttribute GetGlassLensesAttributeById(int glassLensesAttributeId)
        {
            if (glassLensesAttributeId == 0)
                return null;

            var key = string.Format(ModelCacheEventConsumer.GLASSLENSESATTRIBUTEBY_ID_KEY, glassLensesAttributeId);
            return _cacheManager.Get(key, () => _glassLensesAttributeRepository.GetById(glassLensesAttributeId));
        }

        public void InsertGlassLensesAttribute(GlassLensesAttribute glassLensesAttribute)
        {
            if (glassLensesAttribute == null)
                throw new ArgumentNullException(nameof(glassLensesAttribute));

            //insert
            _glassLensesAttributeRepository.Insert(glassLensesAttribute);

            //clear cache
            _cacheManager.RemoveByPattern(ModelCacheEventConsumer.GLASSLENSESATTRIBUTE_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityInserted(glassLensesAttribute);
        }

        public void UpdateGlassLensesAttribute(GlassLensesAttribute glassLensesAttribute)
        {
            if (glassLensesAttribute == null)
                throw new ArgumentNullException(nameof(glassLensesAttribute));

            //update
            _glassLensesAttributeRepository.Update(glassLensesAttribute);

            //cache
            _cacheManager.RemoveByPattern(ModelCacheEventConsumer.GLASSLENSESATTRIBUTE_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityUpdated(glassLensesAttribute);
        }
    }
}
