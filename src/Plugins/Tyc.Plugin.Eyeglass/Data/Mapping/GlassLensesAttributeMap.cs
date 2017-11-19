using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Domain.Lenses;

namespace Tyc.Plugin.Eyeglass.Data.Mapping
{
    public class GlassLensesAttributeMap : NopEntityTypeConfiguration<GlassLensesAttribute>
    {
        public GlassLensesAttributeMap()
        {
            this.ToTable("GlassLensesAttribute");
            this.HasKey(p => p.Id);

            this.HasMany(p => p.GlasssLensesAttributeOptions);
        }
    }
}
