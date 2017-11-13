using Nop.Core.Plugins;
using Nop.Services.Common;
using Nop.Services.Security;

namespace Tyc.Plugin.Eyeglass
{
    public class EyeglassPlugin : BasePlugin, IMiscPlugin
    {
        private readonly IPermissionService _permissionService;

        public EyeglassPlugin(IPermissionService permissionService)
        {
            this._permissionService = permissionService;

        }

        public bool Authenticate()
        {
            return this._permissionService.Authorize(StandardPermissionProvider.ManagePlugins);
        }

    }
}
