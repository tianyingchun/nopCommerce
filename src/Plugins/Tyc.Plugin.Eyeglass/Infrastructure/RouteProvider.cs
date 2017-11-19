using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;

namespace Tyc.Plugin.Eyeglass.Infrastructure
{
    public partial class RouteProvider : IRouteProvider
    {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="routeBuilder">Route builder</param>
        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            //ALLGlassType
            routeBuilder.MapRoute("Plugin.Tyc.EyeglassApi.AllGlassType", "Plugins/EyeglassApi/AllGlassType",
                 new { controller = "EyeglassApi", action = "AllGlassType" });

        }

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority
        {
            get { return -1; }
        }
    }
}
