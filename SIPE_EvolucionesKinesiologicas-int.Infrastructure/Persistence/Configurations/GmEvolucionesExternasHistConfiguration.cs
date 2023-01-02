using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations
{
    public class GmEvolucionesExternasHistConfiguration : IEntityTypeConfiguration<GmEvolucionesExternasHist>
    {
        public void Configure(EntityTypeBuilder<GmEvolucionesExternasHist> builder)
        {
            builder.ToTable("GM_EvolucionesExternas_Hist").HasKey(e => e.IntIdEvolucionHist);

            builder.Property(p => p.IntIdEvolucionHist)
                .HasColumnName("intIdEvolucionHist").IsRequired();

            builder.Property(p => p.IntIdDenuncia)
                .HasColumnName("intIdDenuncia");

            builder.Property(p => p.VarCuil)
                .HasColumnName("varCuil").IsRequired().HasMaxLength(11);

            builder.Property(p => p.VarCuit)
                .HasColumnName("varCuit").HasMaxLength(11);

            builder.Property(p => p.DatFechaAccidente)
                .HasColumnName("datFechaAccidente").IsRequired();

            builder.Property(p => p.VarDescripcionAccidente)
                .HasColumnName("varDescripcionAccidente").IsRequired().HasMaxLength(1000);

            builder.Property(p => p.IntIdNaturalezaLesion)
                .HasColumnName("intIdNaturalezaLesion");

            builder.Property(p => p.ChrIdAgenteCausante)
                .HasColumnName("chrIdAgenteCausante").HasMaxLength(10);

            builder.Property(p => p.IntIdZonaAfectada)
                .HasColumnName("intIdZonaAfectada");

            builder.Property(p => p.VarDiagnostico)
                .HasColumnName("varDiagnostico").HasMaxLength(50);

            builder.Property(p => p.VarEvolucion)
                .HasColumnName("varEvolucion").HasMaxLength(4000);

            builder.Property(p => p.DatFechaDiagnostico)
                .HasColumnName("datFechaDiagnostico").IsRequired();

            builder.Property(p => p.DatFechaProximoControl)
                .HasColumnName("datFechaProximoControl");

            builder.Property(p => p.IntIdTipoSiniestro)
                .HasColumnName("intIdTipoSiniestro");

            builder.Property(p => p.DatFechaModificacion)
                .HasColumnName("datFechaModificacion").IsRequired();

            builder.Property(p => p.IntIdUsuarioModificacion)
                .HasColumnName("intIdUsuarioModificacion").IsRequired();

            builder.Property(p => p.IntIdSeguimientoMed)
                .HasColumnName("intIdSeguimientoMed");

            builder.Property(p => p.VarApellido)
                .HasColumnName("varApellido").IsRequired().HasMaxLength(50);

            builder.Property(p => p.VarNombre)
                .HasColumnName("varNombre").IsRequired().HasMaxLength(50);

            builder.Property(p => p.VarRazonSocial)
                .HasColumnName("varRazonSocial").HasMaxLength(50);

            builder.Property(p => p.IntIdEstado)
                .HasColumnName("intIdEstado").IsRequired();

            builder.Property(p => p.VarMotivoRechazo)
                .HasColumnName("varMotivoRechazo").HasMaxLength(500);

            builder.Property(p => p.IntIdMedico)
               .HasColumnName("intIdMedico").IsRequired();

            builder.Property(p => p.IntIdPrestador)
               .HasColumnName("intIdPrestador").IsRequired();

            builder.Property(p => p.IntIdUsuarioAlta)
               .HasColumnName("intIdUsuarioAlta").IsRequired();

            builder.Property(p => p.IntIdEvolucionExterna)
               .HasColumnName("intIdEvolucionExterna").IsRequired();

            builder.Property(p => p.DatFechaAlta)
               .HasColumnName("datFechaAlta").IsRequired();

            builder.Property(p => p.BitInternado)
               .HasColumnName("bitInternado");

            builder.Property(p => p.BitTraslado)
               .HasColumnName("bitTraslado").IsRequired();

            builder.Property(p => p.IntIdMotivoRechazo)
               .HasColumnName("intIdMotivoRechazo");

            builder.Property(p => p.DatFechaAltaMedica)
               .HasColumnName("datFechaAltaMedica");
        }
    }
}
