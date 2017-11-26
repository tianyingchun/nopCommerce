using Nop.Web.Framework.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyc.Plugin.Eyeglass.Models.Lenses
{
    public partial class GlassLensesAttributeOptionModel : BaseNopModel
    {
        public GlassLensesAttributeOptionModel() { }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string HelpComment { get; set; }

        public string AttributeXml { get; set; }

        public decimal Price { get; set; }

        public decimal OldPrice { get; set; }

        public bool IsPreSelected { get; set; }

        public int DisplayOrder { get; set; }
    }
}
