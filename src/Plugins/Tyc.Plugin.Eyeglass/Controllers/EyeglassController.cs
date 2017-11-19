using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Directory;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyc.Plugin.Eyeglass.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class EyeglassController : BasePluginController
    {
        #region Fields
        private readonly CurrencySettings _currencySettings;
        private readonly IStoreService _storeService;
        private readonly ISettingService _settingService;
        private readonly ICurrencyService _currencyService;
        private readonly IPermissionService _permissionService;
        #endregion

        #region Ctor

        public EyeglassController(CurrencySettings currencySettings,
            ICurrencyService currencyService,
            IPermissionService permissionService,
            ISettingService settingService,
            IStoreService storeService)
        {
            this._currencySettings = currencySettings;
            this._currencyService = currencyService;
            this._permissionService = permissionService;
            this._settingService = settingService;
            this._storeService = storeService;
        }

        #endregion

        #region Methods

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return AccessDeniedView();

            //var model = new ConfigurationModel
            //{
            //    LimitMethodsToCreated = _fixedOrByWeightSettings.LimitMethodsToCreated,
            //    ShippingByWeightEnabled = _fixedOrByWeightSettings.ShippingByWeightEnabled
            //};
            return null;
            //return View("~/Plugins/Shipping.FixedOrByWeight/Views/Configure.cshtml", model);
        }

        #endregion
    }
}
