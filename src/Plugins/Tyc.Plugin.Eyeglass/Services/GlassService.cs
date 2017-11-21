﻿using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Domain;
using Tyc.Plugin.Eyeglass.Domain.Lenses;

namespace Tyc.Plugin.Eyeglass.Services
{
    public class GlassService : IGlassService
    {
        #region Constants

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : glassLenses ID
        /// </remarks>
        private const string GLASSLENSES_BY_ID_KEY = "tyc.glasslenses.id-{0}";
        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        private const string GLASSLENSES_PATTERN_KEY = "tyc.glasslenses.";

        #endregion

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

            //delete product
            _glassLensesRepository.Delete(glassLenses);

            //clear cache
            _cacheManager.RemoveByPattern(GLASSLENSES_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityDeleted(glassLenses);
        }

        public IList<GlassLenses> GetAllGlassLenses()
        {
            var query = from p in _glassLensesRepository.Table
                        orderby p.DisplayOrder, p.Id
                        select p;

            return query.ToList();
        }

        public GlassLenses GetGlassLensesById(int glassLensesId)
        {
            if (glassLensesId == 0)
                return null;

            var key = string.Format(GLASSLENSES_BY_ID_KEY, glassLensesId);
            return _cacheManager.Get(key, () => _glassLensesRepository.GetById(glassLensesId));
        }

        public void InsertGlassLenses(GlassLenses glassLenses)
        {
            if (glassLenses == null)
                throw new ArgumentNullException(nameof(glassLenses));

            //insert
            _glassLensesRepository.Insert(glassLenses);

            //clear cache
            _cacheManager.RemoveByPattern(GLASSLENSES_PATTERN_KEY);

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
            _cacheManager.RemoveByPattern(GLASSLENSES_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityUpdated(glassLenses);
        }
        #endregion

    }
}
