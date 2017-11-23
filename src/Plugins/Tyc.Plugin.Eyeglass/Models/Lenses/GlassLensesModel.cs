using Nop.Web.Framework.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Domain;

namespace Tyc.Plugin.Eyeglass.Models.Lenses
{
    public partial class GlassLensesModel : BaseNopModel
    {
        public GlassLensesModel()
        {
            GlassLensesAttributes = new List<GlassLensesAttributeModel>();
        }

        public IList<GlassLensesAttributeModel> GlassLensesAttributes { get; set; }

        public string Name { get; set; }

  
        public GlassType GlassType { get; set; }

        public string ShortDescription { get; set; }


        public string HelpDescription { get; set; }

        public int DisplayOrder { get; set; }
    } 
}
