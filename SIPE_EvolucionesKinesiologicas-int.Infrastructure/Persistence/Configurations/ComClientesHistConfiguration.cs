using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations
{
    public class ComClientesHistConfiguration : IEntityTypeConfiguration<ComClientesHist>
    {
        public void Configure(EntityTypeBuilder<ComClientesHist> builder)
        {
            builder.HasKey(e => e.IntIdClienteHist)
                    .HasName("PK_COM_ClientesHist_intIdCliente")
                    .IsClustered(false);

            builder.ToTable("COM_ClientesHist");

            builder.HasIndex(e => new { e.IntIdCliente, e.IntIdClienteHist }, "_dta_index_COM_ClientesHist_7_1135811604__K2_K1")
                .HasFillFactor(98);

            builder.Property(e => e.IntIdClienteHist).HasColumnName("intIdClienteHist");

            builder.Property(e => e.ChrCuitcuilcdi)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("chrCUITCUILCDI")
                .IsFixedLength();

            builder.Property(e => e.ChrNivelRiesgo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("chrNivelRiesgo")
                .IsFixedLength();

            builder.Property(e => e.ChrTipoPersona)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("chrTipoPersona")
                .IsFixedLength();

            builder.Property(e => e.DatFechaInicioActividad)
                .HasColumnType("datetime")
                .HasColumnName("datFechaInicioActividad");

            builder.Property(e => e.IntIdCliente).HasColumnName("intIdCliente");

            builder.Property(e => e.IntIdSituacionIva).HasColumnName("intIdSituacionIVA");

            builder.Property(e => e.SmiEstablecimientos).HasColumnName("smiEstablecimientos");

            builder.Property(e => e.VarActOtras)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("varActOtras");

            builder.Property(e => e.VarActividad)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("varActividad");

            builder.Property(e => e.VarIdClienteCrm)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("varIdClienteCRM");

            builder.HasOne(d => d.IntIdClienteNavigation)
                .WithMany(p => p.ComClientesHists)
                .HasForeignKey(d => d.IntIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COM_ClientesHist_COM_Clientes");
        }
    }
}