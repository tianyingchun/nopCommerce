using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using Tyc.Plugin.Eyeglass.Domain.Prescription;
using Tyc.Plugin.Eyeglass.Infrastructure.Cache;


namespace Tyc.Plugin.Eyeglass.Services.Prescription
{
    public partial class PrescriptionService : IPrescriptionService
    {
        #region Fields

        private readonly IRepository<GlassPrescription> _glassPrescriptionRepository;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region Ctor

        public PrescriptionService(
            IRepository<GlassPrescription> glassPrescriptionRepository,
            ICacheManager cacheManager,
            IEventPublisher eventPublisher)
        {
            this._glassPrescriptionRepository = glassPrescriptionRepository;
            this._cacheManager = cacheManager;
            this._eventPublisher = eventPublisher;
        }

        #endregion

        #region Methods

        public void DeletePrescription(GlassPrescription prescription)
        {
            if (prescription == null)
                throw new ArgumentNullException(nameof(prescription));

            //delete
            _glassPrescriptionRepository.Delete(prescription);

            //clear cache
            _cacheManager.RemoveByPattern(ModelCacheEventConsumer.GLASSPRESCRIPTION_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityDeleted(prescription);
        }

        public IList<GlassPrescription> GetAllPrescriptions()
        {

            var query = from p in _glassPrescriptionRepository.Table
                        orderby p.UpdatedOnUtc, p.CreatedOnUtc, p.Id
                        select p;

            return query.ToList();
        }

        public IList<GlassPrescription> GetPrescriptionsByCustomerId(int customerId = 0)
        {
            var key = string.Format(ModelCacheEventConsumer.GLASSPRESCRIPTION_BY_CUSTOMERID_KEY, customerId);
            return _cacheManager.Get(key, () =>
             {
                 var query = _glassPrescriptionRepository.Table;
                 if (customerId > 0)
                     query = query.Where(rph => rph.CustomerId == customerId);

                 return query.OrderByDescending(p => p.UpdatedOnUtc).ToList();
             });

        }


        public GlassPrescription GetPrescriptionById(int prescriptionId)
        {
            if (prescriptionId == 0)
                return null;

            var key = string.Format(ModelCacheEventConsumer.GLASSPRESCRIPTION_BY_ID_KEY, prescriptionId);
            return _cacheManager.Get(key, () => _glassPrescriptionRepository.GetById(prescriptionId));
        }

        public void InsertPrescription(GlassPrescription prescription)
        {
            if (prescription == null)
                throw new ArgumentNullException(nameof(prescription));

            //insert
            _glassPrescriptionRepository.Insert(prescription);

            //clear cache
            _cacheManager.RemoveByPattern(ModelCacheEventConsumer.GLASSPRESCRIPTION_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityInserted(prescription);
        }


        public void UpdatePrescription(GlassPrescription prescription)
        {
            if (prescription == null)
                throw new ArgumentNullException(nameof(prescription));

            //update
            _glassPrescriptionRepository.Update(prescription);

            //cache
            _cacheManager.RemoveByPattern(ModelCacheEventConsumer.GLASSPRESCRIPTION_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityUpdated(prescription);
        }

        #endregion
    }
}
