using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations
{
    public class GmEvolucionesExternasInnominadoConfiguration : IEntityTypeConfiguration<GmEvolucionesExternasInnominado>
    {
        public void Configure(EntityTypeBuilder<GmEvolucionesExternasInnominado> builder)
        {
            builder.ToTable("GM_EvolucionesExternasInnominado").HasKey(e => e.Id);
        
            builder.Property(p => p.Id).HasColumnName("intIdEvolucionExterna");
            builder.Property(p => p.NroDocumento).HasColumnName("varDni");
            builder.Property(p => p.Nombre).HasColumnName("varNombre");
            builder.Property(p => p.Apellido).HasColumnName("varApellido");
            builder.Property(p => p.DocumentoTipoId).HasColumnName("chrTipoDocumento");
            builder.Property(p => p.Sexo).HasColumnName("chrSexo");
        }
    }
}
