using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyc.Plugin.Eyeglass.Controllers
{
    public class EyeglassApiController: BaseEyeglassController
    {
        public EyeglassApiController()
        {

        }
        // API: Plugins/EyeglassApi/AllGlassType
        public IActionResult AllGlassType()
        {
            return Json(new
            {
                code = "0000",
                message = "success",
                data = new { name = "tianyingchun" }
            });
        }
    }
}
