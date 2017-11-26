using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Orders;
using Nop.Services.Catalog;
using Nop.Services.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyc.Plugin.Eyeglass.Services.Checkout
{
    public class LensPriceCalculationService : PriceCalculationService, IPriceCalculationService
    {

        #region Fields

        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly IDiscountService _discountService;
        private readonly ICategoryService _categoryService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IProductAttributeParser _productAttributeParser;
        private readonly IProductService _productService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly ShoppingCartSettings _shoppingCartSettings;
        private readonly CatalogSettings _catalogSettings;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="workContext">Work context</param>
        /// <param name="storeContext">Store context</param>
        /// <param name="discountService">Discount service</param>
        /// <param name="categoryService">Category service</param>
        /// <param name="manufacturerService">Manufacturer service</param>
        /// <param name="productAttributeParser">Product atrribute parser</param>
        /// <param name="productService">Product service</param>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="shoppingCartSettings">Shopping cart settings</param>
        /// <param name="catalogSettings">Catalog settings</param>
        public LensPriceCalculationService(IWorkContext workContext,
            IStoreContext storeContext,
            IDiscountService discountService,
            ICategoryService categoryService,
            IManufacturerService manufacturerService,
            IProductAttributeParser productAttributeParser,
            IProductService productService,
            IStaticCacheManager cacheManager,
            ShoppingCartSettings shoppingCartSettings,
            CatalogSettings catalogSettings) : base(
                workContext, storeContext, discountService,
                categoryService, manufacturerService, productAttributeParser,
                productService, cacheManager, shoppingCartSettings, catalogSettings
            )
        {
            this._workContext = workContext;
            this._storeContext = storeContext;
            this._discountService = discountService;
            this._categoryService = categoryService;
            this._manufacturerService = manufacturerService;
            this._productAttributeParser = productAttributeParser;
            this._productService = productService;
            this._cacheManager = cacheManager;
            this._shoppingCartSettings = shoppingCartSettings;
            this._catalogSettings = catalogSettings;
        }

        #endregion
        /// <summary>
        /// Gets the shopping cart unit price (one item)
        /// </summary>
        /// <param name="shoppingCartItem">The shopping cart item</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for price computation</param>
        /// <returns>Shopping cart unit price (one item)</returns>
        public override decimal GetUnitPrice(ShoppingCartItem shoppingCartItem,
            bool includeDiscounts = true)
        {
            decimal discountAmount;
            List<DiscountForCaching> appliedDiscounts;
            return GetUnitPrice(shoppingCartItem, includeDiscounts,
                out discountAmount, out appliedDiscounts);
        }

        /// <summary>
        /// Gets the shopping cart unit price (one item)
        /// </summary>
        /// <param name="shoppingCartItem">The shopping cart item</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for price computation</param>
        /// <param name="discountAmount">Applied discount amount</param>
        /// <param name="appliedDiscounts">Applied discounts</param>
        /// <returns>Shopping cart unit price (one item)</returns>
        public override decimal GetUnitPrice(ShoppingCartItem shoppingCartItem,
            bool includeDiscounts,
            out decimal discountAmount,
            out List<DiscountForCaching> appliedDiscounts)
        {
            if (shoppingCartItem == null)
                throw new ArgumentNullException(nameof(shoppingCartItem));

            return GetUnitPrice(shoppingCartItem.Product,
                shoppingCartItem.Customer,
                shoppingCartItem.ShoppingCartType,
                shoppingCartItem.Quantity,
                shoppingCartItem.AttributesXml,
                shoppingCartItem.CustomerEnteredPrice,
                shoppingCartItem.RentalStartDateUtc,
                shoppingCartItem.RentalEndDateUtc,
                includeDiscounts,
                out discountAmount,
                out appliedDiscounts);
        }
    }
}
