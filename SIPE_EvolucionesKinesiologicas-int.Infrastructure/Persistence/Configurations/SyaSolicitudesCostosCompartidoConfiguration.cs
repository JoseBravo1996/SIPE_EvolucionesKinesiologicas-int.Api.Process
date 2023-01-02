using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations;
public class SyaSolicitudesCostosCompartidoConfiguration : IEntityTypeConfiguration<SyaSolicitudesCostosCompartido>
{
    public void Configure(EntityTypeBuilder<SyaSolicitudesCostosCompartido> builder)
    {
        builder.HasKey(e => e.IntIdSolicitudCostosCompartidos)
            .HasName("PK_intIdSolicitudCostosCompartidos");

        builder.ToTable("SYA_SolicitudesCostosCompartidos");

        builder.Property(e => e.IntIdSolicitudCostosCompartidos).HasColumnName("intIdSolicitudCostosCompartidos");

        builder.Property(e => e.DatFecha)
            .HasColumnType("datetime")
            .HasColumnName("datFecha");

        builder.Property(e => e.IntIdEstado).HasColumnName("intIdEstado");

        builder.Property(e => e.IntIdUnidadComercial).HasColumnName("intIdUnidadComercial");

        builder.Property(e => e.IntIdUsuario).HasColumnName("intIdUsuario");

        builder.Property(e => e.IntNroCotizacion).HasColumnName("intNroCotizacion");

        builder.Property(e => e.VarObservaciones)
            .HasMaxLength(500)
            .IsUnicode(false)
            .HasColumnName("varObservaciones");

        builder.HasOne(x => x.SyaCotizacionNav)
            .WithMany(x => x.SolicitudesCostosCompartidosNav)
            .HasForeignKey(x => x.IntNroCotizacion)
            .HasPrincipalKey(x => x.IntNroCotizacion);

        builder.Navigation(b => b.SyaCotizacionNav)
            .UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.HasMany(x => x.SyaSolicitudesCostosCompartidosHists)
            .WithOne(s => s.IntIdSolicitudCostosCompartidosNavigation)
            .HasForeignKey(x => x.IntIdSolicitudCostosCompartidos)
            .HasPrincipalKey(x => x.IntIdSolicitudCostosCompartidos);

        builder.Navigation(b => b.SyaSolicitudesCostosCompartidosHists)
            .UsePropertyAccessMode(PropertyAccessMode.Property);
    }
}