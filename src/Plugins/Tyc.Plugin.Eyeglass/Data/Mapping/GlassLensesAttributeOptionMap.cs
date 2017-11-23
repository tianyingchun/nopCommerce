using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Domain.Lenses;

namespace Tyc.Plugin.Eyeglass.Data.Mapping
{
    public class GlassLensesAttributeOptionMap : NopEntityTypeConfiguration<GlassLensesAttributeOption>
    {
        public GlassLensesAttributeOptionMap()
        {
            this.ToTable("GlassLensesAttributeOption");
            this.HasKey(p => p.Id);

            this.HasRequired(p => p.GlassLensesAttribute)
                .WithMany(p => p.GlassLensesAttributeOptions)
                .HasForeignKey(p => p.GlassLensesAttributeId);
        }
    }
}
