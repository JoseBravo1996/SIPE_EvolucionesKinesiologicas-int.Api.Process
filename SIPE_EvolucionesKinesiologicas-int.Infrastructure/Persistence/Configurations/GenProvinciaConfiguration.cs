using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations;
public class GenProvinciaConfiguration : IEntityTypeConfiguration<GenProvincia>
{
    public void Configure(EntityTypeBuilder<GenProvincia> builder)
    {
        builder.HasKey(e => e.IntIdProvincia)
            .HasName("PK_GEN_Provincias_intNroProvincia");

        builder.ToTable("GEN_Provincias");

        builder.Property(e => e.IntIdProvincia)
            .ValueGeneratedNever()
            .HasColumnName("intIdProvincia");

        builder.Property(e => e.ChrCodigoProvincia)
            .HasMaxLength(2)
            .IsUnicode(false)
            .HasColumnName("chrCodigoProvincia")
            .HasDefaultValueSql("('00')")
            .IsFixedLength();

        builder.Property(e => e.VarDescripcion)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("varDescripcion");
    }
}