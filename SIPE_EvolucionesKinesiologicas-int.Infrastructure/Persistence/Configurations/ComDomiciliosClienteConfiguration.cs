using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations
{
    public class ComDomiciliosClienteConfiguration : IEntityTypeConfiguration<ComDomiciliosCliente>
    {
        public void Configure(EntityTypeBuilder<ComDomiciliosCliente> builder)
        {
            builder.HasKey(e => new { e.IntIdCliente, e.IntIdDomicilio, e.IntIdTipoDomicilio })
                    .HasName("PK_COM_DomiciliosCliente_intIdCliente_intIdDomicilio_intIdTipoDomicilio")
                    .IsClustered(false);

            builder.ToTable("COM_DomiciliosCliente");

            builder.HasIndex(e => new { e.IntIdTipoDomicilio, e.IntIdCliente, e.IntIdDomicilio }, "NC_COM_DomiciliosCliente_intIdTipoDomicilio_intIdCliente_intIdDomicilio")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdTipoDomicilio, e.IntIdDomicilio, e.IntIdCliente }, "NC_COM_DomiciliosCliente_intIdTipoDomicilio_intIdDomicilio_intIdCliente")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdCliente, e.IntIdTipoDomicilio, e.IntIdDomicilio }, "_dta_index_COM_DomiciliosCliente_6_1279812117__K1_K3_K2")
                .HasFillFactor(98);

            builder.HasIndex(e => e.IntIdTipoDomicilio, "_dta_index_COM_DomiciliosCliente_6_1279812117__K3_1_2")
                .HasFillFactor(98);

            builder.Property(e => e.IntIdCliente).HasColumnName("intIdCliente");

            builder.Property(e => e.IntIdDomicilio).HasColumnName("intIdDomicilio");

            builder.Property(e => e.IntIdTipoDomicilio).HasColumnName("intIdTipoDomicilio");

            builder.HasOne(d => d.IntIdClienteNavigation)
                .WithMany(p => p.ComDomiciliosClientes)
                .HasForeignKey(d => d.IntIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COM_DomiciliosCliente_COM_Clientes");

            builder.HasOne(d => d.IntIdDomicilioNavigation)
                .WithMany(p => p.ComDomiciliosClientes)
                .HasForeignKey(d => d.IntIdDomicilio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COM_DomiciliosCliente_GEN_Domicilios1");
        }
    }
}