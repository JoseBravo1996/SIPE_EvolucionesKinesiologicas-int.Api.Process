using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations
{
    public class ComClienteConfiguration : IEntityTypeConfiguration<ComCliente>
    {
        public void Configure(EntityTypeBuilder<ComCliente> builder)
        {
            builder.HasKey(e => e.IntIdCliente)
                    .HasName("PK_COM_Clientes_intIdCliente")
                    .IsClustered(false);

            builder.ToTable("COM_Clientes");

            builder.HasIndex(e => e.IntIdSituacionIva, "C_COM_Clientes_intIdSituacionIVA")
                .IsClustered()
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdCliente, e.ChrCuitcuilcdi }, "NC_COM_Clientes_intIdCliente_chrCUITCUILCDI")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdCliente, e.ChrNivelRiesgo }, "NC_COM_Clientes_intIdCliente_chrNivelRiesgo")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdCliente, e.ChrTipoPersona, e.ChrCuitcuilcdi }, "NC_COM_Clientes_intIdCliente_chrTipoPersona_chrCUITCUILCDI")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdCliente, e.ChrCuitcuilcdi }, "NC_intIdCliente_chrTipoPersona_chrCUITCUILCDI")
                .HasFillFactor(98);

            builder.HasIndex(e => e.ChrCuitcuilcdi, "U_COM_Clientes_chrCUITCUILCDI")
                .IsUnique();

            builder.HasIndex(e => e.IntIdCliente, "_dta_index_COM_Clientes_6_1103811490__K1_2")
                .HasFillFactor(98);

            builder.HasIndex(e => e.IntIdCliente, "_dta_index_COM_Clientes_6_1103811490__K1_3")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdCliente, e.ChrCuitcuilcdi }, "_dta_index_COM_Clientes_6_1103811490__K1_K3_2")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdCliente, e.ChrTipoPersona, e.ChrCuitcuilcdi, e.ChrNivelRiesgo }, "_dta_index_COM_Clientes_7_1103811490__K1_K2_K3_K5")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.IntIdCliente, e.IntIdSituacionIva, e.DatFechaInicioActividad, e.SmiEstablecimientos, e.VarActividad, e.ChrNivelRiesgo, e.ChrCuitcuilcdi, e.ChrTipoPersona, e.VarIdClienteCrm }, "_dta_index_COM_Clientes_7_1103811490__K1_K4_K8_K7_K6_K5_K3_K2_K9")
                .HasFillFactor(98);

            builder.HasIndex(e => new { e.ChrCuitcuilcdi, e.IntIdCliente, e.ChrTipoPersona }, "ix_clientes_p_SYA_ConsPagCotizaciones_1")
                .HasFillFactor(98);

            builder.Property(e => e.IntIdCliente).HasColumnName("intIdCliente");

            builder.Property(e => e.BitCuentaEspecial).HasColumnName("bitCuentaEspecial");

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
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("varIdClienteCRM");
        }
    }
}