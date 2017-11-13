using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Tyc.Plugin.Eyeglass.Infrastructure;
using Wangkanai.Responsive;

namespace Tyc.Plugin.Core.Infrastructure
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
        public int Order => 90;

    }
}
