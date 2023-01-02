using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations;
public class SyaCotizacionConfiguration : IEntityTypeConfiguration<SyaCotizacion>
{
    public void Configure(EntityTypeBuilder<SyaCotizacion> builder)
    {
        builder.HasKey(e => e.IntNroCotizacion)
                           .HasName("PK_SYA_Cotizacion_intNroCotizacion")
                           .IsClustered(false);

        builder.ToTable("SYA_Cotizaciones");

        builder.HasIndex(e => e.IntIdCliente, "C_SYA_Cotizaciones_intIdCliente")
            .IsClustered()
            .HasFillFactor(95);

        builder.HasIndex(e => e.ChrCiiuprin, "NC_SYA_Cotizaciones_chrCIIUPrin")
            .HasFillFactor(95);

        builder.HasIndex(e => e.ChrCiiuprinN, "NC_SYA_Cotizaciones_chrCIIUPrinN")
            .HasFillFactor(95);

        builder.HasIndex(e => e.ChrCiiusecun, "NC_SYA_Cotizaciones_chrCIIUSecun")
            .HasFillFactor(95);

        builder.HasIndex(e => e.ChrCiiusecunIi, "NC_SYA_Cotizaciones_chrCIIUSecunII")
            .HasFillFactor(95);

        builder.HasIndex(e => e.ChrCiiusecunIin, "NC_SYA_Cotizaciones_chrCIIUSecunIIN")
            .HasFillFactor(95);

        builder.HasIndex(e => e.ChrCiiusecunN, "NC_SYA_Cotizaciones_chrCIIUSecunN")
            .HasFillFactor(95);

        builder.HasIndex(e => e.IntCodigoArt, "NC_SYA_Cotizaciones_intCodigoART")
            .HasFillFactor(95);

        builder.HasIndex(e => e.IntIdContacto, "NC_SYA_Cotizaciones_intIdContacto")
            .HasFillFactor(95);

        builder.HasIndex(e => e.IntIdProvinciaLegal, "NC_SYA_Cotizaciones_intIdProvinciaLegal")
            .HasFillFactor(95);

        builder.HasIndex(e => e.IntIdProvinciaRiesgo, "NC_SYA_Cotizaciones_intIdProvinciaRiesgo")
            .HasFillFactor(95);

        builder.HasIndex(e => e.IntIdSiniestroAgrupado, "NC_SYA_Cotizaciones_intIdSiniestroAgrupado")
            .HasFillFactor(95);

        builder.HasIndex(e => e.IntIdSiniestroProyeccion, "NC_SYA_Cotizaciones_intIdSiniestroProyeccion")
            .HasFillFactor(95);

        builder.HasIndex(e => new { e.IntIdEstado, e.IntTrabajadores }, "idx_sya_coti_estado_trabajadores")
            .HasFillFactor(95);

        builder.HasIndex(e => new { e.IntIdEstado, e.ChrTipoCotizacion, e.IntIdDelegacion, e.IntNroCotizacion }, "ix_cotizaciones_p_SYA_ConsPagCotizPendientes_1")
            .HasFillFactor(95);

        builder.HasIndex(e => new { e.ChrTipoCotizacion, e.IntIdCliente, e.IntIdEstado, e.IntIdDelegacion, e.IntNroCotizacion }, "ix_cotizaciones_p_SYA_ConsPagCotizaciones_1")
            .HasFillFactor(95);

        builder.HasIndex(e => new { e.ChrTipoCotizacion, e.IntNroCotizacion, e.IntIdCliente, e.IntIdEstado, e.IntIdDelegacion }, "ix_cotizaciones_p_SYA_ConsPagCotizaciones_2")
            .HasFillFactor(95);

        builder.HasIndex(e => new { e.ChrTipoCotizacion, e.ChrCiiuprin, e.IntIdCliente, e.IntIdEstado, e.IntIdDelegacion, e.IntNroCotizacion }, "ix_cotizaciones_p_SYA_ConsPagCotizaciones_3")
            .HasFillFactor(95);

        builder.HasIndex(e => new { e.ChrTipoCotizacion, e.IntIdCliente, e.IntIdEstado, e.IntIdDelegacion, e.IntNroCotizacion }, "ix_cotizaciones_p_SYA_ConsPagCotizaciones_5")
            .HasFillFactor(95);

        builder.Property(e => e.IntNroCotizacion).HasColumnName("intNroCotizacion");

        builder.Property(e => e.BitLibreDeuda).HasColumnName("bitLibreDeuda");

        builder.Property(e => e.BitMoroso).HasColumnName("bitMoroso");

        builder.Property(e => e.BitPausaEtp)
            .HasColumnName("bitPausaETP")
            .HasDefaultValueSql("(0)");

        builder.Property(e => e.BitRegularizado).HasColumnName("bitRegularizado");

        builder.Property(e => e.BitTraspaso).HasColumnName("bitTraspaso");

        builder.Property(e => e.ChrCiiuprin)
            .HasMaxLength(6)
            .IsUnicode(false)
            .HasColumnName("chrCIIUPrin")
            .IsFixedLength();

        builder.Property(e => e.ChrCiiuprinN)
            .HasMaxLength(6)
            .IsUnicode(false)
            .HasColumnName("chrCIIUPrinN")
            .IsFixedLength();

        builder.Property(e => e.ChrCiiuprinRev4)
            .HasMaxLength(6)
            .IsUnicode(false)
            .HasColumnName("chrCIIUPrinRev4")
            .IsFixedLength();

        builder.Property(e => e.ChrCiiusecIirev4)
            .HasMaxLength(6)
            .IsUnicode(false)
            .HasColumnName("chrCIIUSecIIRev4")
            .IsFixedLength();

        builder.Property(e => e.ChrCiiusecRev4)
            .HasMaxLength(6)
            .IsUnicode(false)
            .HasColumnName("chrCIIUSecRev4")
            .IsFixedLength();

        builder.Property(e => e.ChrCiiusecun)
            .HasMaxLength(6)
            .IsUnicode(false)
            .HasColumnName("chrCIIUSecun")
            .IsFixedLength();

        builder.Property(e => e.ChrCiiusecunIi)
            .HasMaxLength(6)
            .IsUnicode(false)
            .HasColumnName("chrCIIUSecunII")
            .IsFixedLength();

        builder.Property(e => e.ChrCiiusecunIin)
            .HasMaxLength(6)
            .IsUnicode(false)
            .HasColumnName("chrCIIUSecunIIN")
            .IsFixedLength();

        builder.Property(e => e.ChrCiiusecunN)
            .HasMaxLength(6)
            .IsUnicode(false)
            .HasColumnName("chrCIIUSecunN")
            .IsFixedLength();

        builder.Property(e => e.ChrTipoCotizacion)
            .HasMaxLength(1)
            .IsUnicode(false)
            .HasColumnName("chrTipoCotizacion")
            .IsFixedLength();

        builder.Property(e => e.DatCreado)
            .HasColumnType("datetime")
            .HasColumnName("datCreado");

        builder.Property(e => e.DatFechaEstado)
            .HasColumnType("datetime")
            .HasColumnName("datFechaEstado");

        builder.Property(e => e.DatFechaImpresion)
            .HasColumnType("datetime")
            .HasColumnName("datFechaImpresion");

        builder.Property(e => e.DecCmpVar)
            .HasColumnType("decimal(6, 3)")
            .HasColumnName("decCmpVar");

        builder.Property(e => e.IntCantEstablecimiento).HasColumnName("intCantEstablecimiento");

        builder.Property(e => e.IntCodigoArt).HasColumnName("intCodigoART");

        builder.Property(e => e.IntIdCliente).HasColumnName("intIdCliente");

        builder.Property(e => e.IntIdContacto).HasColumnName("intIdContacto");

        builder.Property(e => e.IntIdDelegacion).HasColumnName("intIdDelegacion");

        builder.Property(e => e.IntIdDomicilio).HasColumnName("intIdDomicilio");

        builder.Property(e => e.IntIdEstado).HasColumnName("intIdEstado");

        builder.Property(e => e.IntIdMetodo).HasColumnName("intIdMetodo");

        builder.Property(e => e.IntIdProvinciaLegal).HasColumnName("intIdProvinciaLegal");

        builder.Property(e => e.IntIdProvinciaRiesgo).HasColumnName("intIdProvinciaRiesgo");

        builder.Property(e => e.IntIdSiniestroAgrupado).HasColumnName("intIdSiniestroAgrupado");

        builder.Property(e => e.IntIdSiniestroProyeccion).HasColumnName("intIdSiniestroProyeccion");

        builder.Property(e => e.IntIdTipoVentaCotizacion).HasColumnName("intIdTipoVentaCotizacion");

        builder.Property(e => e.IntIdUnidadComercial).HasColumnName("intIdUnidadComercial");

        builder.Property(e => e.IntIdUsuario).HasColumnName("intIdUsuario");

        builder.Property(e => e.IntIdUsuarioImpresion).HasColumnName("intIdUsuarioImpresion");

        builder.Property(e => e.IntNivelRiesgo).HasColumnName("intNivelRiesgo");

        builder.Property(e => e.IntTrabajadores).HasColumnName("intTrabajadores");

        builder.Property(e => e.MonCmpAnual)
            .HasColumnType("money")
            .HasColumnName("monCmpAnual");

        builder.Property(e => e.MonCmpCxT)
            .HasColumnType("money")
            .HasColumnName("monCmpCxT");

        builder.Property(e => e.MonCmpFijo)
            .HasColumnType("money")
            .HasColumnName("monCmpFijo");

        builder.Property(e => e.MonCmpMensual)
            .HasColumnType("money")
            .HasColumnName("monCmpMensual");

        builder.Property(e => e.MonMasaSalarial)
            .HasColumnType("money")
            .HasColumnName("monMasaSalarial");

        builder.Property(e => e.MonPromCiiu)
            .HasColumnType("money")
            .HasColumnName("monPromCIIU");

        builder.Property(e => e.VarActividadEspec)
            .HasMaxLength(250)
            .IsUnicode(false)
            .HasColumnName("varActividadEspec");

        builder.Property(e => e.VarApellido)
            .HasMaxLength(60)
            .IsUnicode(false)
            .HasColumnName("varApellido");

        builder.Property(e => e.VarNombre)
            .HasMaxLength(60)
            .IsUnicode(false)
            .HasColumnName("varNombre");

        builder.Property(e => e.VarRazonSocial)
            .HasMaxLength(80)
            .IsUnicode(false)
        .HasColumnName("varRazonSocial");

        builder.HasMany(x => x.SolicitudesCostosCompartidosNav)
            .WithOne(s => s.SyaCotizacionNav)
            .HasForeignKey(x => x.IntNroCotizacion)
            .HasPrincipalKey(x => x.IntNroCotizacion);

        builder.Navigation(b => b.SolicitudesCostosCompartidosNav)
            .UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.HasMany(x => x.UnidadComercialesNav)
            .WithOne(s => s.SyaCotizacionNav)
            .HasForeignKey(x => x.IntNroCotizacion)
            .HasPrincipalKey(x => x.IntNroCotizacion);

        builder.Navigation(b => b.UnidadComercialesNav)
            .UsePropertyAccessMode(PropertyAccessMode.Property);
    }
}