using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyc.Plugin.Eyeglass.Domain.Lenses
{
    public partial class GlassLensesAttribute: BaseEntity
    {
        private ICollection<GlassLensesAttributeOption> _glasssLensesAttributeOptions;


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
        /// Gets or sets the specification attribute options
        /// </summary>
        public virtual ICollection<GlassLensesAttributeOption> GlasssLensesAttributeOptions
        {
            get { return _glasssLensesAttributeOptions ?? (_glasssLensesAttributeOptions = new List<GlassLensesAttributeOption>()); }
            protected set { _glasssLensesAttributeOptions = value; }
        }


    }
}
