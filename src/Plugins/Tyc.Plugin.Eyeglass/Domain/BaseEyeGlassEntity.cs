using Nop.Core;
using System;

namespace Tyc.Plugin.Eyeglass.Domain
{
    public partial class BaseEyeGlassEntity : BaseEntity
    {
        public BaseEyeGlassEntity()
        {
            this.CreatedOnUtc = DateTime.UtcNow;
            this.UpdatedOnUtc = DateTime.UtcNow;
        }
        /// <summary>
        /// Gets or sets the date and time of product creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of product update
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }
    }
}
