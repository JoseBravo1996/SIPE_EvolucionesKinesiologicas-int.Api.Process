using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations;
public class SyaDatosComplementariosCotizacionDomesticaConfiguration : IEntityTypeConfiguration<SyaDatosComplementariosCotizacionDomestica>
{
    public void Configure(EntityTypeBuilder<SyaDatosComplementariosCotizacionDomestica> builder)
    {
        builder.HasKey(e => e.IntIdDatosComplementariosCotizacionDomestica)
            .HasName("PK__SYA_DatosComplem__6F5E26A7");

        builder.ToTable("SYA_DatosComplementariosCotizacionDomestica");

        builder.Property(e => e.IntIdDatosComplementariosCotizacionDomestica).HasColumnName("intIdDatosComplementariosCotizacionDomestica");

        builder.Property(e => e.IntCantidadTrabajadores).HasColumnName("intCantidadTrabajadores");

        builder.Property(e => e.IntCategoriaTrabajador).HasColumnName("intCategoriaTrabajador");

        builder.Property(e => e.IntNroCotizacion).HasColumnName("intNroCotizacion");

        builder.HasOne(d => d.IntNroCotizacionNavigation)
            .WithMany(p => p.SyaDatosComplementariosCotizacionDomesticas)
            .HasForeignKey(d => d.IntNroCotizacion)
            .HasConstraintName("FK__SYA_Datos__intNr__70524AE0");
    }
}