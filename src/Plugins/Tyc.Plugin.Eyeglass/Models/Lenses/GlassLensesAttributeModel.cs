using Nop.Web.Framework.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Domain.Lenses;

namespace Tyc.Plugin.Eyeglass.Models.Lenses
{
    public partial class GlassLensesAttributeModel: BaseNopModel
    {
        public GlassLensesAttributeModel() {

        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }

    }
}
