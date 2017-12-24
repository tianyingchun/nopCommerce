using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyc.Plugin.Eyeglass.Domain.Tryon
{
    public partial class GlassTryon : BaseEyeGlassEntity
    {
        /// <summary>
        /// Gets or sets the store identifier
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        ///  try on glass left eye position X
        ///  0.2689
        /// </summary>
        public string LeftX { get; set; }

        /// <summary>
        ///  try on glass left eye position Y
        ///  0.4274
        /// </summary>
        public string LeftY { get; set; }

        /// <summary>
        ///  try on glass right eye position X
        ///  0.4824
        /// </summary>
        public string RightX { get; set; }

        /// <summary>
        ///  try on glass right eye position Y
        ///  0.4107
        /// </summary>
        public string RightY { get; set; }

        /// <summary>
        ///  try on glass PD (Pupillary Distance)
        ///  66 
        /// </summary>
        public string PD { get; set; }

        /// <summary>
        /// try on picture cropped url
        /// </summary>
        public string Url { get; set; }


    }
}
