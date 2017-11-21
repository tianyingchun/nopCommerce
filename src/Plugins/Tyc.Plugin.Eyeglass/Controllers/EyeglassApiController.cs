using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Services;

namespace Tyc.Plugin.Eyeglass.Controllers
{
    public class EyeglassApiController : BaseEyeglassController
    {
        private readonly IGlassService _glassService;

        public EyeglassApiController(IGlassService glassService)
        {
            this._glassService = glassService;
        }
        // API: Plugins/TycApi/EyeglassApi/AllGlassType
        public IActionResult AllGlassType()
        {
            return this.JsonOk(new { name = "tianyingchun" });
        }

        [Route("Plugins/TycApi/EyeglassApi/GetAllGlassLenses")]
        public IActionResult GetAllGlassLenses()
        {
            var result = _glassService.GetAllGlassLenses();
            return this.JsonOk(result);
        }
    }
}
