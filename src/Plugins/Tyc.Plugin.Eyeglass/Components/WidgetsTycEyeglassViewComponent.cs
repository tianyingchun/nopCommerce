using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Models.Catalog;
using Tyc.Plugin.Eyeglass.Models.Lenses;
using Tyc.Plugin.Eyeglass.Services.Lenses;

namespace Tyc.Plugin.Eyeglass.Components
{
    [ViewComponent(Name = "WidgetsTycEyeglass")]
    public class WidgetsTycEyeglassViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IGlassService _glassService;
        public WidgetsTycEyeglassViewComponent(IStoreContext storeContext,
            IStaticCacheManager cacheManager,
            IGlassService glassService
            )
        {
            this._storeContext = storeContext;
            this._cacheManager = cacheManager;
            this._glassService = glassService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var model = new SelectLensesModel();
            var allGlassLenses = _glassService.GetAllGlassLenses();
            var result = new List<GlassLensesModel>();
            foreach (var item in allGlassLenses)
            {
                var glassModel = new GlassLensesModel
                {
                    Name = item.Name,
                    GlassType = item.GlassType,
                    DisplayOrder = item.DisplayOrder,
                    HelpDescription = item.HelpDescription,
                    ShortDescription = item.ShortDescription
                };
                result.Add(glassModel);
            }
            model.ProductDetailsModel = additionalData as ProductDetailsModel;
            model.GlassLensesItems = result.ToList();

            return View("~/Plugins/Tyc.Eyeglass/Views/Product/SelectLensesButton.cshtml", model);
        }

    }
}
