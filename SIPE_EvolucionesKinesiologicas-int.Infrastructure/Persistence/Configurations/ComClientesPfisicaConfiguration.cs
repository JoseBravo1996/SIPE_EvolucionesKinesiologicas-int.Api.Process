using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations
{
    public class ComClientesPfisicaConfiguration : IEntityTypeConfiguration<ComClientesPfisica>
    {
        public void Configure(EntityTypeBuilder<ComClientesPfisica> builder)
        {
            builder.HasKey(e => e.IntIdCliente)
                    .HasName("PK_COM_ClientesPFisicas_intIdCliente");

            builder.ToTable("COM_ClientesPFisicas");

            builder.HasIndex(e => new { e.IntIdCliente, e.VarApellido, e.VarNombre }, "NC_COM_ClientesPFisicas_intIdCliente_varApellido_varNombre")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdCliente, e.VarNombre, e.VarApellido }, "NC_COM_ClientesPFisicas_intIdCliente_varNombre_varApellido")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.VarApellido, e.VarNombre }, "NC_COM_ClientesPFisicas_varApellido_varNombre")
                .HasFillFactor(98);

            builder.HasIndex(e => e.IntIdCliente, "_dta_index_COM_ClientesPFisicas_6_1151811661__K1_2_3")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.VarApellido, e.VarNombre }, "ix_clientesPFisicas_p_SYA_BuscarDatosContrato_1")
                .HasFillFactor(98);

            builder.Property(e => e.IntIdCliente)
                .ValueGeneratedNever()
                .HasColumnName("intIdCliente");

            builder.Property(e => e.ChrCiuo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("chrCIUO")
                .IsFixedLength();

            builder.Property(e => e.ChrNroDocumento)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("chrNroDocumento")
                .IsFixedLength();

            builder.Property(e => e.ChrSexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("chrSexo")
                .IsFixedLength();

            builder.Property(e => e.ChrTipoDocumento)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("chrTipoDocumento")
                .IsFixedLength();

            builder.Property(e => e.DatFechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("datFechaNacimiento");

            builder.Property(e => e.IntIdEstadoCivil).HasColumnName("intIdEstadoCivil");

            builder.Property(e => e.IntIdNacionalidad).HasColumnName("intIdNacionalidad");

            builder.Property(e => e.VarApellido)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("varApellido");

            builder.Property(e => e.VarLugarNacimiento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("varLugarNacimiento");

            builder.Property(e => e.VarNombre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("varNombre");

            builder.Property(e => e.VarOcupacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("varOcupacion");

            builder.HasOne(d => d.IntIdClienteNavigation)
                .WithOne(p => p.ComClientesPfisica)
                .HasForeignKey<ComClientesPfisica>(d => d.IntIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COM_ClientesPFisicas_COM_Clientes");
        }
    }
}