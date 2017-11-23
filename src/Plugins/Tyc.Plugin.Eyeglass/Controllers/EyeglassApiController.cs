using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Models.Lenses;
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
            var allGlassLenses = _glassService.GetAllGlassLenses();
            var result = new List<GlassLensesModel>();
            foreach (var item in allGlassLenses)
            {
                var model = new GlassLensesModel
                {
                    Name = item.Name,
                    GlassType = item.GlassType,
                    DisplayOrder = item.DisplayOrder,
                    HelpDescription = item.HelpDescription,
                    ShortDescription = item.ShortDescription
                };
                foreach (var attribute in item.GlassLensesAttributes)
                {
                    model.GlassLensesAttributes.Add(new GlassLensesAttributeModel
                    {
                        Name = attribute.Name,
                        Description = attribute.Description,
                        DisplayOrder = attribute.DisplayOrder
                    });
                }
                result.Add(model);
            }
           
            return this.JsonOk(result);
        }
    }
}
