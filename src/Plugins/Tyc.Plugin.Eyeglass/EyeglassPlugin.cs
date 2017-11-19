using System.Collections.Generic;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Common;
using Nop.Services.Security;
using Tyc.Plugin.Eyeglass.Data;
using Nop.Core;

namespace Tyc.Plugin.Eyeglass
{
    public class EyeglassPlugin : BasePlugin, IMiscPlugin, IWidgetPlugin
    {
        private readonly GlassObjectContext _objectContext;
        private readonly IWebHelper _webHelper;


        public EyeglassPlugin(GlassObjectContext objectContext,
            IWebHelper webHelper)
        {
            this._objectContext = objectContext;
            this._webHelper = webHelper;

        }
        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { "productdetails_select_lenses" };
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            // controller:  Eyeglas, action: Configure.
            return _webHelper.GetStoreLocation() + "Admin/Eyeglass/Configure";
        }

        /// <summary>
        /// Gets a view component for displaying plugin in public store
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <param name="viewComponentName">View component name</param>
        public void GetPublicViewComponent(string widgetZone, out string viewComponentName)
        {
            viewComponentName = "WidgetsTycEyeglass";
        }

        public override void Install()
        {
            //database objects
            _objectContext.Install();
            base.Install();
        }
        public override void Uninstall()
        {
            //database objects
            _objectContext.Uninstall();
            base.Uninstall();
        }

    }
}
