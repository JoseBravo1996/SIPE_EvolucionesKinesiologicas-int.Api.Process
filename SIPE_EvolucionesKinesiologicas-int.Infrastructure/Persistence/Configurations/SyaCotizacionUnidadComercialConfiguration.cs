using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations;
public class SyaCotizacionUnidadComercialConfiguration : IEntityTypeConfiguration<SyaCotizacionUnidadComercial>
{
    public void Configure(EntityTypeBuilder<SyaCotizacionUnidadComercial> builder)
    {
        builder.HasKey(e => new { e.IntNroCotizacion, e.IntIdUnidadComercial });

        builder.ToTable("SYA_CotizacionUnidadComercial");

        builder.Property(e => e.IntNroCotizacion).HasColumnName("intNroCotizacion");

        builder.Property(e => e.IntIdUnidadComercial).HasColumnName("intIdUnidadComercial");

        builder.Property(e => e.DatFechaIncorporacion)
            .HasColumnType("datetime")
            .HasColumnName("datFechaIncorporacion");

        builder.HasOne(x => x.SyaCotizacionNav)
            .WithMany(x => x.UnidadComercialesNav)
            .HasForeignKey(x => x.IntNroCotizacion)
            .HasPrincipalKey(x => x.IntNroCotizacion);

        builder.Navigation(b => b.SyaCotizacionNav)
            .UsePropertyAccessMode(PropertyAccessMode.Property);
    }
}