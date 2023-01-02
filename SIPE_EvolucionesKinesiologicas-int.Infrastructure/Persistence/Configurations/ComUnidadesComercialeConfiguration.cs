using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations;
public class ComUnidadesComercialeConfiguration : IEntityTypeConfiguration<ComUnidadesComerciale>
{
    public void Configure(EntityTypeBuilder<ComUnidadesComerciale> builder)
    {
        builder.HasKey(e => e.IntIdUnidadComercial)
            .HasName("PK_COM_UnidadesComerciales_intIdUnidadComercial")
            .IsClustered(false);

        builder.ToTable("COM_UnidadesComerciales");

        builder.HasIndex(e => e.VarIdUnidadComercialCrm, "NC_COM_UnidadesComerciales_varIdUnidadComercialCRM ")
            .HasFillFactor(95);

        builder.Property(e => e.IntIdUnidadComercial)
            .ValueGeneratedNever()
            .HasColumnName("intIdUnidadComercial");

        builder.Property(e => e.BitUcdirecta)
            .HasColumnName("bitUCDirecta")
            .HasDefaultValueSql("((1))");

        builder.Property(e => e.DatFechaEliminacion)
            .HasColumnType("datetime")
            .HasColumnName("datFechaEliminacion");

        builder.Property(e => e.DatFechaVigenciaHasta)
            .HasColumnType("datetime")
            .HasColumnName("datFechaVigenciaHasta");

        builder.Property(e => e.IntIdDelegacion).HasColumnName("intIdDelegacion");

        builder.Property(e => e.VarIdUnidadComercialCrm)
            .HasMaxLength(60)
            .IsUnicode(false)
            .HasColumnName("varIdUnidadComercialCRM");

        builder.Property(e => e.VarLoginEc)
            .HasMaxLength(11)
            .IsUnicode(false)
            .HasColumnName("varLoginEC");
    }
}