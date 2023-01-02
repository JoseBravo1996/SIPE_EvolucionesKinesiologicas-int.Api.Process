using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations
{
    public class GmEvolucionExternaIntermediaConfiguration : IEntityTypeConfiguration<GmEvolucionesExternasIntermedia>
    {
        public void Configure(EntityTypeBuilder<GmEvolucionesExternasIntermedia> builder)
        {
            builder.ToTable("GM_EvolucionesExternas_Intermedia", "integracion").HasKey(e => e.EvolucionMedicaDboId);
            
        }
    }
}
