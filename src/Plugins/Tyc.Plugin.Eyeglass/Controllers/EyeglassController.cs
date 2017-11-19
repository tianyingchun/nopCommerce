using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Directory;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc.Filters;
using Tyc.Plugin.Eyeglass.Models;
namespace Tyc.Plugin.Eyeglass.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class EyeglassController : BaseEyeglassController
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


        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePlugins))
                return AccessDeniedView();

            var model = new ConfigurationModel
            {

            };
            return View("~/Plugins/Tyc.Eyeglass/Views/Configure.cshtml", model);
        }
        [HttpPost]
        [AuthorizeAdmin]
        [AdminAntiForgery]
        [Area(AreaNames.Admin)]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePlugins))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return Configure();

            return Content("hey this is post return view");
        }


        #endregion
    }
}
