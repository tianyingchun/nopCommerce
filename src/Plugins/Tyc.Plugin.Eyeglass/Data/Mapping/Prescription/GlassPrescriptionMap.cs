using Nop.Data.Mapping;
using Tyc.Plugin.Eyeglass.Domain.Prescription;

namespace Tyc.Plugin.Eyeglass.Data.Mapping.Prescription
{
    public class GlassPrescriptionMap : NopEntityTypeConfiguration<GlassPrescription>
    {
        public GlassPrescriptionMap()
        {
            this.ToTable("GlassPrescription");
            this.HasKey(x => x.Id);
        }
    }
}
