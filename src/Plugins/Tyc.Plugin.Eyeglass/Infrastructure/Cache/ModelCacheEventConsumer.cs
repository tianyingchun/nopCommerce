using Nop.Core.Caching;
using Nop.Core.Events;
using Nop.Services.Events;
using Tyc.Plugin.Eyeglass.Domain.Lenses;
using Tyc.Plugin.Eyeglass.Domain.Prescription;

namespace Tyc.Plugin.Eyeglass.Infrastructure.Cache
{
    /// <summary>
    /// Model cache event consumer (used for caching of presentation layer models)
    /// </summary>
    public partial class ModelCacheEventConsumer :
        IConsumer<EntityInserted<GlassLenses>>,
        IConsumer<EntityUpdated<GlassLenses>>,
        IConsumer<EntityDeleted<GlassLenses>>,

        IConsumer<EntityInserted<GlassPrescription>>,
        IConsumer<EntityUpdated<GlassPrescription>>,
        IConsumer<EntityDeleted<GlassPrescription>>,


        IConsumer<EntityInserted<GlassLensesAttribute>>,
        IConsumer<EntityUpdated<GlassLensesAttribute>>,
        IConsumer<EntityDeleted<GlassLensesAttribute>>
    {
   
        // For GlassLenses Table cache
        public const string GLASSLENSES_BY_ID_KEY = "tyc.plugins.eyeglass.glasslenses-{0}";
        public const string GLASSLENSES_LIST_KEY = "tyc.plugins.eyeglass.glasslenses.list";
        public const string GLASSLENSES_PATTERN_KEY = "tyc.plugins.eyeglass.glasslenses";

        // For GlassPrescription Table cache
        public const string GLASSPRESCRIPTION_BY_ID_KEY = "tyc.plugins.eyeglass.glassprescription-{0}";
        public const string GLASSPRESCRIPTION_BY_CUSTOMERID_KEY = "tyc.plugins.eyeglass.glassprescription.customerid-{0}";
        public const string GLASSPRESCRIPTION_PATTERN_KEY = "tyc.plugins.eyeglass.glassprescription";

        // For GlassLensesAttribute table cache
        public const string GLASSLENSESATTRIBUTEBY_ID_KEY = "tyc.plugins.eyeglass.glasslensesattribute-{0}";
        public const string GLASSLENSESATTRIBUTEBY_GLASSLENSES_ID_KEY = "tyc.plugins.eyeglass.glasslensesattribute.glasslenses-{0}";
        public const string GLASSLENSESATTRIBUTE_PATTERN_KEY = "tyc.plugins.eyeglass.glasslensesattribute";
        
        private readonly IStaticCacheManager _cacheManager;

        public ModelCacheEventConsumer(IStaticCacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
        }

        public void HandleEvent(EntityInserted<GlassLenses> eventMessage)
        {
            _cacheManager.RemoveByPattern(GLASSLENSES_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<GlassLenses> eventMessage)
        {
            _cacheManager.RemoveByPattern(GLASSLENSES_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<GlassLenses> eventMessage)
        {
            _cacheManager.RemoveByPattern(GLASSLENSES_PATTERN_KEY);
        }

     

        public void HandleEvent(EntityInserted<GlassPrescription> eventMessage)
        {
            _cacheManager.RemoveByPattern(GLASSPRESCRIPTION_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<GlassPrescription> eventMessage)
        {
            _cacheManager.RemoveByPattern(GLASSPRESCRIPTION_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<GlassPrescription> eventMessage)
        {
            _cacheManager.RemoveByPattern(GLASSPRESCRIPTION_PATTERN_KEY);
        }

        public void HandleEvent(EntityInserted<GlassLensesAttribute> eventMessage)
        {
            _cacheManager.RemoveByPattern(GLASSLENSESATTRIBUTE_PATTERN_KEY);
            _cacheManager.RemoveByPattern(GLASSLENSES_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<GlassLensesAttribute> eventMessage)
        {
            _cacheManager.RemoveByPattern(GLASSLENSESATTRIBUTE_PATTERN_KEY);
            _cacheManager.RemoveByPattern(GLASSLENSES_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<GlassLensesAttribute> eventMessage)
        {
            _cacheManager.RemoveByPattern(GLASSLENSESATTRIBUTE_PATTERN_KEY);
            _cacheManager.RemoveByPattern(GLASSLENSES_PATTERN_KEY);
        }
    }
}