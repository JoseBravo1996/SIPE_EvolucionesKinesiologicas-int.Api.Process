using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations
{
    public class GenDomicilioConfiguration : IEntityTypeConfiguration<GenDomicilio>
    {
        public void Configure(EntityTypeBuilder<GenDomicilio> builder)
        {
            builder.HasKey(e => e.IntIdDomicilio)
                    .HasName("PK_GEN_Domicilios_intIdDomicilio")
                    .IsClustered(false);

            builder.ToTable("GEN_Domicilios");

            builder.HasIndex(e => e.IntIdDomicilio, "C_GEN_Domicilios_intIdDomicilio")
                .IsUnique()
                .IsClustered()
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdDomicilio, e.IntIdCalle, e.IntIdLocalidad, e.IntIdProvDesnormalizada, e.ChrDpto, e.ChrPiso, e.VarNumero, e.VarCalleDesnormalizada, e.VarLocDesnormalizada, e.ChrCodigoPostal, e.VarCpdesnormalizado, e.ChrCpa, e.VarBarrio, e.VarEntreCalle1, e.VarEntreCalle2 }, "NC_GEN_Domicilios_Desnormalizado")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdDomicilio, e.VarNumero, e.ChrPiso, e.ChrDpto, e.VarLocDesnormalizada, e.VarCalleDesnormalizada }, "NC_intIdDomicilio_varNumero_chrPiso_chrDpto_varLocDesnormalizada_varCalleDesnormalizada")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdProvDesnormalizada, e.IntIdDomicilio }, "_dta_index_GEN_Domicilios_6_1314220578__K15_K1_12_14")
                .HasFillFactor(98);

            builder.HasIndex(e => e.IntIdDomicilio, "_dta_index_GEN_Domicilios_6_1314220578__K1_4_5_6_12_13")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdDomicilio, e.ChrPiso, e.ChrDpto, e.VarLocDesnormalizada, e.VarCalleDesnormalizada }, "ix_GEN_Domicilios_intIdDomicilio_chrPiso_chrDpto_varLocDesnormalizada_varCalleDesnormalizada")
                .HasFillFactor(98);

            builder.Property(e => e.IntIdDomicilio).HasColumnName("intIdDomicilio");

            builder.Property(e => e.ChrCodigoPostal)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("chrCodigoPostal")
                .IsFixedLength();

            builder.Property(e => e.ChrCpa)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("chrCPA")
                .IsFixedLength();

            builder.Property(e => e.ChrDpto)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("chrDpto")
                .IsFixedLength();

            builder.Property(e => e.ChrNormal)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("chrNormal")
                .HasDefaultValueSql("('PEN')")
                .IsFixedLength();

            builder.Property(e => e.ChrPiso)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("chrPiso")
                .IsFixedLength();

            builder.Property(e => e.DatFecha)
                .HasColumnType("datetime")
                .HasColumnName("datFecha")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.DatFechaAlta)
                .HasColumnType("datetime")
                .HasColumnName("datFechaAlta");

            builder.Property(e => e.DatFechaBaja)
                .HasColumnType("datetime")
                .HasColumnName("datFechaBaja");

            builder.Property(e => e.DatFechaModif)
                .HasColumnType("datetime")
                .HasColumnName("datFechaModif");

            builder.Property(e => e.IntIdCalle).HasColumnName("intIdCalle");

            builder.Property(e => e.IntIdLocalidad).HasColumnName("intIdLocalidad");

            builder.Property(e => e.IntIdPais)
                .HasColumnName("intIdPais")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.IntIdProvDesnormalizada).HasColumnName("intIdProvDesnormalizada");

            builder.Property(e => e.IntIdUsuarioAlta).HasColumnName("intIdUsuarioAlta");

            builder.Property(e => e.IntIdUsuarioBaja).HasColumnName("intIdUsuarioBaja");

            builder.Property(e => e.IntIdUsuarioModif).HasColumnName("intIdUsuarioModif");

            builder.Property(e => e.VarBarrio)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("varBarrio");

            builder.Property(e => e.VarCalleDesnormalizada)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("varCalleDesnormalizada");

            builder.Property(e => e.VarCpdesnormalizado)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("varCPDesnormalizado");

            builder.Property(e => e.VarEntreCalle1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("varEntreCalle1");

            builder.Property(e => e.VarEntreCalle2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("varEntreCalle2");

            builder.Property(e => e.VarIdDomicilioCrm)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("varIdDomicilioCRM");

            builder.Property(e => e.VarLocDesnormalizada)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("varLocDesnormalizada");

            builder.Property(e => e.VarNumero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("varNumero");

            builder.Property(e => e.VarPaisDesnormalizado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("varPaisDesnormalizado");

            builder.Property(e => e.VarPartidoDepartamento)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("varPartidoDepartamento");

            builder.Property(e => e.VarProvinciaExtranjera)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("varProvinciaExtranjera");
        }
    }
}