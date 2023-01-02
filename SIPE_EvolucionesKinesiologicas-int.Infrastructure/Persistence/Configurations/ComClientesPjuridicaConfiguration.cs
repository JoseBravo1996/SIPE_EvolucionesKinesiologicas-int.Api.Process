using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations
{
    public class ComClientesPjuridicaConfiguration : IEntityTypeConfiguration<ComClientesPjuridica>
    {
        public void Configure(EntityTypeBuilder<ComClientesPjuridica> builder)
        {
            builder.HasKey(e => e.IntIdCliente)
                    .HasName("PK_COM_ClientesPJuridicas_intIdCliente");

            builder.ToTable("COM_ClientesPJuridicas");

            builder.HasIndex(e => new { e.IntIdCliente, e.VarRazonSocial }, "NC_COM_ClientesPJuridicas_intIdCliente_varRazonSocial")
                .HasFillFactor(98);

            builder.HasIndex(e => e.VarRazonSocial, "NC_COM_ClientesPJuridicas_varRazonSocial")
                .HasFillFactor(98);

            builder.HasIndex(e => e.IntIdCliente, "_dta_index_COM_ClientesPJuridicas_6_1183811775__K1_2")
                .HasFillFactor(98);

            builder.Property(e => e.IntIdCliente)
                .ValueGeneratedNever()
                .HasColumnName("intIdCliente");

            builder.Property(e => e.DatFechaConstitucion)
                .HasColumnType("datetime")
                .HasColumnName("datFechaConstitucion");

            builder.Property(e => e.IntIdRegistro).HasColumnName("intIdRegistro");

            builder.Property(e => e.VarIibb)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("varIIBB");

            builder.Property(e => e.VarNumeroInscripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("varNumeroInscripcion");

            builder.Property(e => e.VarProtocoloNotarial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("varProtocoloNotarial");

            builder.Property(e => e.VarRazonSocial)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("varRazonSocial");

            builder.HasOne(d => d.IntIdClienteNavigation)
                .WithOne(p => p.ComClientesPjuridica)
                .HasForeignKey<ComClientesPjuridica>(d => d.IntIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COM_ClientesPJuridicas_COM_Clientes");
        }
    }
}