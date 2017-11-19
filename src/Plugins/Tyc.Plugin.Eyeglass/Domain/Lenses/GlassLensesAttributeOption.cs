using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyc.Plugin.Eyeglass.Domain.Lenses
{
    public partial class GlassLensesAttributeOption : BaseEntity
    {

        /// <summary>
        /// Gets or sets the attribute value type identifier
        /// </summary>
        public int GlasssLensesAttributeId { get; set; }

        /// <summary>
        /// Gets or sets the glasslenses attribute name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the glasslenses short description
        /// </summary>
        public string ShortDescription { get; set; }


        /// <summary>
        /// Gets or sets the glasslenses attribute helper comments
        /// </summary>
        public string HelpComment { get; set; }

        /// <summary>
        /// Gets or sets the values indicates if current record depends on the parent glass lenses attribute option id has checked.
        /// </summary>
        public int ParentGlassLensesAttributeOptionId { get; set; }

        /// <summary>
        /// Gets or sets a option extension child attributes e.g color : red, black ...
        /// </summary>
        public string AttributeXml { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the old price
        /// </summary>
        public decimal OldPrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value is pre-selected
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the GlasssLenses attribute
        /// </summary>
        public virtual GlassLensesAttribute GlasssLensesAttribute { get; set; }


    }
}
