using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Domain.Tryon;

namespace Tyc.Plugin.Eyeglass.Data.Mapping.Tryon
{
    public class GlassTryonMap : NopEntityTypeConfiguration<GlassTryon>
    {
        public GlassTryonMap()
        {
            this.ToTable("GlassTryon");
            this.HasKey(x => x.Id);
        }
    }
}
