using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using Tyc.Plugin.Eyeglass.Domain.Lenses;
using Tyc.Plugin.Eyeglass.Infrastructure.Cache;

namespace Tyc.Plugin.Eyeglass.Services.Lenses
{
    public class GlassService : IGlassService
    {

        #region Fields

        private readonly IRepository<GlassLenses> _glassLensesRepository;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region Ctor

        public GlassService(
            IRepository<GlassLenses> glassLensesRepository,
            ICacheManager cacheManager,
            IEventPublisher eventPublisher)
        {
            this._glassLensesRepository = glassLensesRepository;
            this._cacheManager = cacheManager;
            this._eventPublisher = eventPublisher;
        }

        #endregion

        #region Methods
        public void DeleteGlassLenses(GlassLenses glassLenses)
        {
            if (glassLenses == null)
                throw new ArgumentNullException(nameof(glassLenses));

            //delete
            _glassLensesRepository.Delete(glassLenses);

            //clear cache
            _cacheManager.RemoveByPattern(ModelCacheEventConsumer.GLASSLENSES_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityDeleted(glassLenses);
        }

        public IList<GlassLenses> GetAllGlassLenses()
        {
            var key = string.Format(ModelCacheEventConsumer.GLASSLENSES_LIST_KEY);

            return _cacheManager.Get(key, () =>
            {
                var query = from p in _glassLensesRepository.Table
                            orderby p.DisplayOrder, p.Id
                            select p;

                return query.ToList();
            });

        }

        public GlassLenses GetGlassLensesById(int glassLensesId)
        {
            if (glassLensesId == 0)
                return null;

            var key = string.Format(ModelCacheEventConsumer.GLASSLENSES_BY_ID_KEY, glassLensesId);
            return _cacheManager.Get(key, () => _glassLensesRepository.GetById(glassLensesId));
        }

        public void InsertGlassLenses(GlassLenses glassLenses)
        {
            if (glassLenses == null)
                throw new ArgumentNullException(nameof(glassLenses));

            //insert
            _glassLensesRepository.Insert(glassLenses);

            //clear cache
            _cacheManager.RemoveByPattern(ModelCacheEventConsumer.GLASSLENSES_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityInserted(glassLenses);
        }

        public void UpdateGlassLenses(GlassLenses glassLenses)
        {
            if (glassLenses == null)
                throw new ArgumentNullException(nameof(glassLenses));

            //update
            _glassLensesRepository.Update(glassLenses);

            //cache
            _cacheManager.RemoveByPattern(ModelCacheEventConsumer.GLASSLENSES_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityUpdated(glassLenses);
        }
        #endregion

    }
}
