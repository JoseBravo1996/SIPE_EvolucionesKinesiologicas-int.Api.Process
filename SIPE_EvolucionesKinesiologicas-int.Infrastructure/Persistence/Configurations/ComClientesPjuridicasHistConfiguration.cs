using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations
{
    public class ComClientesPjuridicasHistConfiguration : IEntityTypeConfiguration<ComClientesPjuridicasHist>
    {
        public void Configure(EntityTypeBuilder<ComClientesPjuridicasHist> builder)
        {
            builder.HasKey(e => e.IntIdClientePjuridicaHist)
                    .HasName("PK_COM_ClientesPJuridicasHist_intIdCliente")
                    .IsClustered(false);

            builder.ToTable("COM_ClientesPJuridicasHist");

            builder.Property(e => e.IntIdClientePjuridicaHist).HasColumnName("intIdClientePJuridicaHist");

            builder.Property(e => e.DatFechaConstitucion)
                .HasColumnType("datetime")
                .HasColumnName("datFechaConstitucion");

            builder.Property(e => e.IntIdCliente).HasColumnName("intIdCliente");

            builder.Property(e => e.IntIdClienteHist).HasColumnName("intIdClienteHist");

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
                .WithMany(p => p.ComClientesPjuridicasHists)
                .HasForeignKey(d => d.IntIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COM_ClientesPJuridicasHist_COM_ClientesPJuridicas");

            builder.HasOne(d => d.IntIdClienteHistNavigation)
                .WithMany(p => p.ComClientesPjuridicasHists)
                .HasForeignKey(d => d.IntIdClienteHist)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COM_ClientesPJuridicasHist_COM_ClientesHist");
        }
    }
}