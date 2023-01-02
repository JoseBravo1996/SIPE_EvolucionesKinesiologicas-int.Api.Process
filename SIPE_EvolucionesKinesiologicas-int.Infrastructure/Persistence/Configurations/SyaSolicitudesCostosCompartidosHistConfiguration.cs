using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations;
public class SyaSolicitudesCostosCompartidosHistConfiguration : IEntityTypeConfiguration<SyaSolicitudesCostosCompartidosHist>
{
    public void Configure(EntityTypeBuilder<SyaSolicitudesCostosCompartidosHist> builder)
    {
        builder.HasKey(e => e.IntIdSolicitudCostosCompartidosHist)
            .HasName("PK_intIdSolicitudCostosCompartidosHist");

        builder.ToTable("SYA_SolicitudesCostosCompartidosHist");

        builder.Property(e => e.IntIdSolicitudCostosCompartidosHist).HasColumnName("intIdSolicitudCostosCompartidosHist");

        builder.Property(e => e.DatFecha)
            .HasColumnType("datetime")
            .HasColumnName("datFecha");

        builder.Property(e => e.DatFechaModif)
            .HasColumnType("datetime")
            .HasColumnName("datFechaModif");

        builder.Property(e => e.IntIdEstado).HasColumnName("intIdEstado");

        builder.Property(e => e.IntIdSolicitudCostosCompartidos).HasColumnName("intIdSolicitudCostosCompartidos");

        builder.Property(e => e.IntIdUnidadComercial).HasColumnName("intIdUnidadComercial");

        builder.Property(e => e.IntIdUsuario).HasColumnName("intIdUsuario");

        builder.Property(e => e.IntIdUsuarioModif).HasColumnName("intIdUsuarioModif");

        builder.Property(e => e.IntNroCotizacion).HasColumnName("intNroCotizacion");

        builder.Property(e => e.VarObservaciones)
            .HasMaxLength(500)
            .IsUnicode(false)
            .HasColumnName("varObservaciones");

        builder.HasOne(d => d.IntIdSolicitudCostosCompartidosNavigation)
            .WithMany(p => p.SyaSolicitudesCostosCompartidosHists)
            .HasForeignKey(d => d.IntIdSolicitudCostosCompartidos)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SYA_SolicitudesCostosCompartidosHist_SYA_SolicitudesCostosCompartidos");

        builder.HasOne(x => x.SyaCotizacionNav)
            .WithMany()
            .HasForeignKey(x => x.IntNroCotizacion)
            .HasPrincipalKey(x => x.IntNroCotizacion);

        builder.Navigation(b => b.SyaCotizacionNav)
            .UsePropertyAccessMode(PropertyAccessMode.Property);
    }
}