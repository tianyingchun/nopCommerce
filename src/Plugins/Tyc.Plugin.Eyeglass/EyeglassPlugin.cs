using Nop.Core.Plugins;
using Nop.Services.Common;
using Nop.Services.Security;
using Tyc.Plugin.Eyeglass.Data;

namespace Tyc.Plugin.Eyeglass
{
    public class EyeglassPlugin : BasePlugin, IMiscPlugin
    {
        private readonly IPermissionService _permissionService;
        private readonly GlassObjectContext _objectContext;


        public EyeglassPlugin(IPermissionService permissionService, GlassObjectContext objectContext)
        {
            this._permissionService = permissionService;
            this._objectContext = objectContext;
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
        public bool Authenticate()
        {
            return this._permissionService.Authorize(StandardPermissionProvider.ManagePlugins);
        }

    }
}
