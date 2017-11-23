using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Domain;
using Tyc.Plugin.Eyeglass.Domain.Lenses;

namespace Tyc.Plugin.Eyeglass.Data.Mapping
{
    class GlassLensesMap : NopEntityTypeConfiguration<GlassLenses>
    {
        public GlassLensesMap()
        {
            this.ToTable("GlassLenses");
            this.HasKey(x => x.Id);
            this.Ignore(p => p.GlassType);

            this.HasMany(p => p.GlassLensesAttributes);
        }
    }
}
