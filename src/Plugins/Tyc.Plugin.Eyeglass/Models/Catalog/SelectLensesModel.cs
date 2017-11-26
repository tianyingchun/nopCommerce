using Nop.Web.Framework.Mvc.Models;
using Nop.Web.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Models.Lenses;

namespace Tyc.Plugin.Eyeglass.Models.Catalog
{
    public class SelectLensesModel : BaseNopEntityModel
    {
        public SelectLensesModel()
        {
            GlassLensesItems = new List<GlassLensesModel>();
        }
        public ProductDetailsModel ProductDetailsModel { get; set; }

        public IList<GlassLensesModel> GlassLensesItems { get; set; }
    }
}
