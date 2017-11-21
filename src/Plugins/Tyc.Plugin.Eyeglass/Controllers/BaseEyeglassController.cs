using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Controllers;

namespace Tyc.Plugin.Eyeglass.Controllers
{
    public class BaseEyeglassController : BasePluginController
    {
        public virtual IActionResult JsonOk(dynamic data, string message = "success")
        {
            return Json(new
            {
                code = "0000",
                message = message,
                data = data
            });
        }
    }
}
