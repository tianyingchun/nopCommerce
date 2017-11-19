using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyc.Plugin.Eyeglass.Domain.Lenses
{
    /// <summary>
    /// Represents a glass
    /// </summary>
    public partial class GlassLenses : BaseEntity
    {
        private ICollection<GlassLensesAttribute> _glassLensesAttributes;

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the glass type identifier
        /// </summary>
        public int GlassTypeId { get; set; }

        /// <summary>
        /// Gets or sets the short description
        /// </summary>
        public string ShortDescription { get; set; }


        /// <summary>
        /// Gets or sets the help description(html) for each glass type
        /// </summary>
        public string HelpDescription { get; set; }

    
        /// <summary>
        /// Gets or sets the product type
        /// </summary>
        public GlassType GlassType
        {
            get
            {
                return (GlassType)GlassTypeId;
            }
            set
            {
                GlassTypeId = (int)value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of ProductCategory
        /// </summary>
        public virtual ICollection<GlassLensesAttribute> GlassLensesAttributes
        {
            get { return _glassLensesAttributes ?? (_glassLensesAttributes = new List<GlassLensesAttribute>()); }
            protected set { _glassLensesAttributes = value; }
        }


    }
}
