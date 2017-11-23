using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Web.Framework.Controllers;

namespace Tyc.Plugin.Eyeglass.Controllers
{
    public class BaseEyeglassController : BasePluginController
    {
        public virtual IActionResult JsonOk(object data, string message = "success")
        {
            return Json(new
            {
                code = "0000",
                message = message,
                data = data
            },
            new JsonSerializerSettings()
            {
                // Note avoid loop detected for property 
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }
    }
}
