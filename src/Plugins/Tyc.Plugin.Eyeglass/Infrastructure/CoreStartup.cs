using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Wangkanai.Responsive;

namespace Tyc.Plugin.Eyeglass.Infrastructure
{
    public class CoreStartup : INopStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            //themes support
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new CoreThemeViewLocationExpander());
            });

            //device detection: TIANYIGNCHUN install-package Wangkanai.Responsive -pre
            services.AddResponsive().AddViewSuffix().AddViewSubfolder();
        }

        public void Configure(IApplicationBuilder application)
        {
            //device detection: TIANYIGNCHUN install-package Wangkanai.Responsive -pre
            application.UseResponsive();
        }

        // NopCommonStartup Order==100
        // Make sure this plugin <INopStartup> will be loaded after Nop.Web.Framework
        // Theme finder orders: 
        // $"/Plugins/Tyc.Eyeglass/Themes/{theme}/Views/{{1}}/{{0}}.cshtml",
        // $"/Plugins/Tyc.Eyeglass/Themes/{theme}/Views/Shared/{{0}}.cshtml",
        // $"/Plugins/Tyc.Eyeglass/Views/{{1}}/{{0}}.cshtml",
        // $"/Plugins/Tyc.Eyeglass/Views/Shared/{{0}}.cshtml",
        // $"/Themes/{theme}/Views/{{1}}/{{0}}.cshtml",
        // $"/Themes/{theme}/Views/Shared/{{0}}.cshtml",
        // $"/Views/{{1}}/{{0}}.cshtml",
        // $"/Views/Shared/{{0}}.cshtml",
        public int Order => 110;

    }
}
