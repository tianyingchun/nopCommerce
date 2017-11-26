using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyc.Plugin.Eyeglass.Domain.Lenses
{
    public partial class GlassLensesAttribute : BaseEyeGlassEntity
    {
        private ICollection<GlassLensesAttributeOption> _glassLensesAttributeOptions;


        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// / Gets or sets the Glass lenses identifier
        /// </summary>
        public int GlassLensesId { get; set; }

        /// <summary>
        /// / Gets or sets the Glass lenses
        /// </summary>
        public GlassLenses GlassLenses { get; set; }

        /// <summary>
        /// / Gets or sets the GlassLensesAttributeType Identifier
        /// </summary>
        public int GlassLensesAttributeTypeId { get; set; }

        /// <summary>
        /// / Gets or sets the GlassLensesAttributeType
        /// </summary>
        public GlassLensesAttributeType GlassLensesAttributeType
        {
            get
            {
                return (GlassLensesAttributeType)GlassLensesAttributeTypeId;
            }
            set
            {
                GlassLensesAttributeTypeId = (int)value;
            }
        }

        /// <summary>
        /// Gets or sets the specification attribute options
        /// </summary>
        public virtual ICollection<GlassLensesAttributeOption> GlassLensesAttributeOptions
        {
            get { return _glassLensesAttributeOptions ?? (_glassLensesAttributeOptions = new List<GlassLensesAttributeOption>()); }
            protected set { _glassLensesAttributeOptions = value; }
        }


    }
}
