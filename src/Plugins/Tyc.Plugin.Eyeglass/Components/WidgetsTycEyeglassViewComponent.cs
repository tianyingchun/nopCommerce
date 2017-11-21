using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Web.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyc.Plugin.Eyeglass.Components
{
    [ViewComponent(Name = "WidgetsTycEyeglass")]
    public class WidgetsTycEyeglassViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _cacheManager;

        public WidgetsTycEyeglassViewComponent(IStoreContext storeContext,
            IStaticCacheManager cacheManager)
        {
            this._storeContext = storeContext;
            this._cacheManager = cacheManager;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            return Content("hey this is widget");
        }

    }
}
