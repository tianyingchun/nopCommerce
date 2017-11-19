using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyc.Plugin.Eyeglass.Domain
{
    /// <summary>
    /// Represents the kind of glass
    /// </summary>
    public enum GlassType
    {
        /// <summary>
        /// General use lenses for seeing things far away
        /// </summary>
        Distance = 1,

        /// <summary>
        /// To see near/magnifications
        /// </summary>
        Reader = 2,

        /// <summary>
        /// To block all blue-light from computer, phone, iPad, etc and greatly relieve visual fatigue.
        /// </summary>
        ComputerBlueLight = 4,

        /// <summary>
        /// To see both distance and near
        /// </summary>
        BifocalProgressive = 8,

        /// <summary>
        /// I need non-prescription lenses for my glasses.
        /// </summary>
        NonRx = 16
    }
}
