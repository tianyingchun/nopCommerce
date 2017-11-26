using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyc.Plugin.Eyeglass.Domain
{
    /// <summary>
    /// Represents the kind of glass attributes
    /// </summary>
    public enum GlassLensesAttributeType
    {
        /// <summary>
        /// LensesAttribute Thickness
        /// </summary>
        LensThickness = 1,

        /// <summary>
        /// LensesAttribute Color
        /// </summary>
        LensColor = 2,

        /// <summary>
        /// LensesAttribute coatings
        /// </summary>
        LensCoatings = 4,

        /// <summary>
        /// LensesAttribute bifocal lens
        /// </summary>
        BifocalTypes = 8
    }
}
