using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations
{
    public class ComClientesPfisicasHistConfiguration : IEntityTypeConfiguration<ComClientesPfisicasHist>
    {
        public void Configure(EntityTypeBuilder<ComClientesPfisicasHist> builder)
        {
            builder.HasKey(e => e.IntIdClientePfisicaHist)
                    .HasName("PK_COM_ClientesPFisicasHist_intIdCliente")
                    .IsClustered(false);

            builder.ToTable("COM_ClientesPFisicasHist");

            builder.Property(e => e.IntIdClientePfisicaHist).HasColumnName("intIdClientePFisicaHist");

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

            builder.Property(e => e.IntIdCliente).HasColumnName("intIdCliente");

            builder.Property(e => e.IntIdClienteHist).HasColumnName("intIdClienteHist");

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
                .WithMany(p => p.ComClientesPfisicasHists)
                .HasForeignKey(d => d.IntIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COM_ClientesPFisicasHist_COM_ClientesPFisicas");

            builder.HasOne(d => d.IntIdClienteHistNavigation)
                .WithMany(p => p.ComClientesPfisicasHists)
                .HasForeignKey(d => d.IntIdClienteHist)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COM_ClientesPFisicasHist_COM_ClientesHist");
        }
    }
}