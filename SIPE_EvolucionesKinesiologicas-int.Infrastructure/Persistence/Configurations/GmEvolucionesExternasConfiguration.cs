using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations
{
    public class GmEvolucionesExternasConfiguration : IEntityTypeConfiguration<GmEvolucionesExternas>
    {
        public void Configure(EntityTypeBuilder<GmEvolucionesExternas> builder)
        {
            builder.ToTable("GM_EvolucionesExternas").HasKey(e => e.Id);

            builder.Property(p => p.Id).HasColumnName("intIdEvolucionExterna");
            builder.Property(p => p.NroDenuncia).HasColumnName("intIdDenuncia");
            builder.Property(p => p.Cuil).HasColumnName("varCuil");
            builder.Property(p => p.Cuit).HasColumnName("varCuit");
            builder.Property(p => p.DelegacionOrigenId).HasColumnName("intIdDelegacionOrigen");
            builder.Property(p => p.FechaAccidente).HasColumnName("datFechaAccidente");
            builder.Property(p => p.SiniestroDescripcion).HasColumnName("varDescripcionAccidente");
            builder.Property(p => p.Diagnostico).HasColumnName("varDiagnostico");
            builder.Property(p => p.EvolucionDescripcion).HasColumnName("varEvolucion");
            builder.Property(p => p.datFechaDiagnostico).HasColumnName("datFechaDiagnostico");
            builder.Property(p => p.FechaProximoControl).HasColumnName("datFechaProximoControl");
            builder.Property(p => p.SiniestroTipoId).HasColumnName("intIdTipoSiniestro");
            builder.Property(p => p.NaturalezaLesionId).HasColumnName("intIdNaturalezaLesion");
            builder.Property(p => p.AgenteMaterialId).HasColumnName("chrIdAgenteCausante");
            builder.Property(p => p.ZonaAfectadaId).HasColumnName("intIdZonaAfectada");
            builder.Property(p => p.FechaEvolucion).HasColumnName("datFechaAlta");
            builder.Property(p => p.ManoHabil).HasColumnName("varManoHabil");
            builder.Property(p => p.EmpleadorRazonSocial).HasColumnName("varRazonSocial");
            builder.Property(p => p.NroSiniestro).HasColumnName("intNroSiniestro");
            builder.Property(p => p.MedicoId).HasColumnName("intIdMedico");
			builder.Property(p => p.PrestadorId).HasColumnName("intIdPrestador");
            builder.Property(p => p.bitInternado).HasColumnName("bitInternado");
            builder.Property(p => p.NecesitaTraslado).HasColumnName("bitTraslado");
            builder.Property(p => p.FechaAltaMedica).HasColumnName("datFechaAltaMedica");
        }
    }
}
