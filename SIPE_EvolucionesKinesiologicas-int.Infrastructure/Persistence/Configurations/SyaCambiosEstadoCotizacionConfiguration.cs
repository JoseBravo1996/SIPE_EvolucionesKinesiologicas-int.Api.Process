using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations;
public class SyaCambiosEstadoCotizacionConfiguration : IEntityTypeConfiguration<SyaCambiosEstadoCotizacion>
{
    public void Configure(EntityTypeBuilder<SyaCambiosEstadoCotizacion> builder)
    {

        builder.HasKey(e => e.IntIdCambioEstadoCotizacion)
                    .HasName("PK_SYA_CambiosEstadoCotizacion_intIdCambioEstadoCotizacion")
                    .IsClustered(false);

        builder.ToTable("SYA_CambiosEstadoCotizacion");

        builder.HasIndex(e => e.IntNroCotizacion, "C_SYA_CambiosEstadoCotizacion_intNroCotizacion")
            .HasFillFactor(95);

        builder.HasIndex(e => new { e.IntNroCotizacion, e.IntIdUsuario }, "C_SYA_CambiosEstadoCotizacion_intNroCotizacion_intIdUsuario")
            .IsClustered()
            .HasFillFactor(95);

        builder.HasIndex(e => new { e.IntNroCotizacion, e.IntIdCambioEstadoCotizacion }, "NC_DESC_SYA_CambiosEstadoCotizacion_intNroCotizacion")
            .HasFillFactor(95);

        builder.HasIndex(e => e.IntNroCotizacion, "NC_SYA_CambiosEstadoCotizacion_intNroCotizacion")
            .HasFillFactor(95);

        builder.HasIndex(e => e.IntIdEstado, "idx_sya_cec_intIdEstado")
            .HasFillFactor(95);

        builder.Property(e => e.IntIdCambioEstadoCotizacion).HasColumnName("intIdCambioEstadoCotizacion");

        builder.Property(e => e.BitPausaEtp)
            .HasColumnName("bitPausaETP")
            .HasDefaultValueSql("(0)");

        builder.Property(e => e.DatFechaCambio)
            .HasColumnType("datetime")
            .HasColumnName("datFechaCambio");

        builder.Property(e => e.DecCalVar)
            .HasColumnType("decimal(6, 3)")
            .HasColumnName("decCalVar");

        builder.Property(e => e.DecComVar)
            .HasColumnType("decimal(6, 3)")
            .HasColumnName("decComVar");

        builder.Property(e => e.DecPpvar)
            .HasColumnType("decimal(6, 3)")
            .HasColumnName("decPPVar");

        builder.Property(e => e.DecSsnvar)
            .HasColumnType("decimal(6, 3)")
            .HasColumnName("decSSNVar");

        builder.Property(e => e.DecSugVar)
            .HasColumnType("decimal(6, 3)")
            .HasColumnName("decSugVar");

        builder.Property(e => e.DecVar)
            .HasColumnType("decimal(6, 3)")
            .HasColumnName("decVar");

        builder.Property(e => e.IntIdEstado).HasColumnName("intIdEstado");

        builder.Property(e => e.IntIdTipoTarifa).HasColumnName("intIdTipoTarifa");

        builder.Property(e => e.IntIdUsuario).HasColumnName("intIdUsuario");

        builder.Property(e => e.IntNroCotizacion).HasColumnName("intNroCotizacion");

        builder.Property(e => e.MonAnual)
            .HasColumnType("money")
            .HasColumnName("monAnual");

        builder.Property(e => e.MonCalAnual)
            .HasColumnType("money")
            .HasColumnName("monCalAnual");

        builder.Property(e => e.MonCalCxT)
            .HasColumnType("money")
            .HasColumnName("monCalCxT");

        builder.Property(e => e.MonCalFijo)
            .HasColumnType("money")
            .HasColumnName("monCalFijo");

        builder.Property(e => e.MonCalMensual)
            .HasColumnType("money")
            .HasColumnName("monCalMensual");

        builder.Property(e => e.MonComAnual)
            .HasColumnType("money")
            .HasColumnName("monComAnual");

        builder.Property(e => e.MonComCxT)
            .HasColumnType("money")
            .HasColumnName("monComCxT");

        builder.Property(e => e.MonComFijo)
            .HasColumnType("money")
            .HasColumnName("monComFijo");

        builder.Property(e => e.MonComMensual)
            .HasColumnType("money")
            .HasColumnName("monComMensual");

        builder.Property(e => e.MonCxT)
            .HasColumnType("money")
            .HasColumnName("monCxT");

        builder.Property(e => e.MonFijo)
            .HasColumnType("money")
            .HasColumnName("monFijo");

        builder.Property(e => e.MonMensual)
            .HasColumnType("money")
            .HasColumnName("monMensual");

        builder.Property(e => e.MonPpanual)
            .HasColumnType("money")
            .HasColumnName("monPPAnual");

        builder.Property(e => e.MonPpcxT)
            .HasColumnType("money")
            .HasColumnName("monPPCxT");

        builder.Property(e => e.MonPpfijo)
            .HasColumnType("money")
            .HasColumnName("monPPFijo");

        builder.Property(e => e.MonPpmensual)
            .HasColumnType("money")
            .HasColumnName("monPPMensual");

        builder.Property(e => e.MonSsnanual)
            .HasColumnType("money")
            .HasColumnName("monSSNAnual");

        builder.Property(e => e.MonSsncxT)
            .HasColumnType("money")
            .HasColumnName("monSSNCxT");

        builder.Property(e => e.MonSsnfijo)
            .HasColumnType("money")
            .HasColumnName("monSSNFijo");

        builder.Property(e => e.MonSsnmensual)
            .HasColumnType("money")
            .HasColumnName("monSSNMensual");

        builder.Property(e => e.MonSugAnual)
            .HasColumnType("money")
            .HasColumnName("monSugAnual");

        builder.Property(e => e.MonSugCxT)
            .HasColumnType("money")
            .HasColumnName("monSugCxT");

        builder.Property(e => e.MonSugFijo)
            .HasColumnType("money")
            .HasColumnName("monSugFijo");

        builder.Property(e => e.MonSugMensual)
            .HasColumnType("money")
            .HasColumnName("monSugMensual");

        builder.Property(e => e.VarObservaciones)
            .HasMaxLength(250)
            .IsUnicode(false)
            .HasColumnName("varObservaciones");

        builder.HasOne(d => d.IntNroCotizacionNavigation)
            .WithMany(p => p.SyaCambiosEstadoCotizacions)
            .HasForeignKey(d => d.IntNroCotizacion)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SYA_CambiosEstadoCotizacion_SYA_Cotizaciones");
    }
}