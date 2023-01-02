using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Domain.Entities;
using SIPE_Evolucion.Domain.Enum;

namespace SIPE_Evolucion.Application.Spd.Service;

public  class IntegracionCotizacionService : IIntegracionCotizacionService
{
    private readonly IIntegracionUnidadesComerciales _integracionUnidadesComerciales;
    private readonly IIntegracionDatosDomesticaService _datosCotizacionDomesticaService;
    private readonly IIntegracionCambiosEstadoCotizacionService _cambiosEstadoSpdService;
    private readonly IIntegracionCostosCompartidosService _solicitudesCostosCompartidoService;

    public IntegracionCotizacionService(IIntegracionUnidadesComerciales integracionUnidadesComerciales, IIntegracionDatosDomesticaService datosDomesticaSpdService, 
        IIntegracionCambiosEstadoCotizacionService cambiosEstadoSpdService, IIntegracionCostosCompartidosService integrarSolicitudesCostos) 
    {
        _integracionUnidadesComerciales = integracionUnidadesComerciales; 
        _solicitudesCostosCompartidoService = integrarSolicitudesCostos;
        _datosCotizacionDomesticaService = datosDomesticaSpdService;
        _cambiosEstadoSpdService = cambiosEstadoSpdService;
    }

    public async Task<SyaCotizacion> CreateCotizacion(CotizacionPoliza cotizacionPoliza, ComUnidadesComerciale unidadComercial, int clienteId)
    {
        var cotizacion = await Task.Run(() => new SyaCotizacion()
        {
            DatCreado = cotizacionPoliza.DatCreado,
            IntIdCotizacionReingenieria = cotizacionPoliza.IntIdCotizacionReingenieria,
            IntIdCliente = clienteId,
            IntTrabajadores = cotizacionPoliza.IntTrabajadores,
            MonMasaSalarial = cotizacionPoliza.MonMasaSalarial,
            IntIdProvinciaLegal = cotizacionPoliza.IntIdProvinciaLegal,
            IntIdProvinciaRiesgo = cotizacionPoliza.IntIdProvinciaRiesgo,
            IntNivelRiesgo = cotizacionPoliza.IntNivelRiesgo,
            BitMoroso = null,
            BitLibreDeuda = null,
            BitRegularizado = false,
            IntIdUnidadComercial = unidadComercial.IntIdUnidadComercial,
            IntIdDelegacion = cotizacionPoliza.IntIdDelegacion,
            DatFechaEstado = cotizacionPoliza.DatFechaEstado,
            IntIdEstado = (int)EstadosCotizacion.Aprobada,
            IntCodigoArt = cotizacionPoliza.IntCodigoArt,
            ChrCiiuprin = cotizacionPoliza.ChrCiiuprin.Length == 5 ? $"0{cotizacionPoliza.ChrCiiuprin}" : $"{cotizacionPoliza.ChrCiiuprin}",
            ChrCiiuprinN = cotizacionPoliza.ChrCiiuprinN.Length == 5 ? $"0{cotizacionPoliza.ChrCiiuprinN}" : $"{cotizacionPoliza.ChrCiiuprinN}",
            ChrCiiusecunIi = null,
            ChrCiiusecunIin = null,
            ChrCiiusecunN = null,
            VarActividadEspec = cotizacionPoliza.VarActividadEspec,
            MonCmpFijo = cotizacionPoliza.MonCmpFijo,
            DecCmpVar = cotizacionPoliza.DecCmpVar,
            MonCmpCxT = cotizacionPoliza.MonCmpCxT,
            MonCmpMensual = cotizacionPoliza.MonCmpMensual,
            MonCmpAnual = cotizacionPoliza.MonCmpAnual,
            IntIdContacto = null,
            IntIdDomicilio = null,
            IntCantEstablecimiento = null,
            IntIdSiniestroAgrupado = null,
            IntIdSiniestroProyeccion = null,
            MonPromCiiu = null,
            ChrTipoCotizacion = "C",
            IntIdMetodo = null,
            BitTraspaso = cotizacionPoliza.BitTraspaso,
            VarNombre = cotizacionPoliza.VarNombre,
            VarApellido = cotizacionPoliza.VarApellido,
            VarRazonSocial = cotizacionPoliza.VarRazonSocial,
            BitPausaEtp = false,
            DatFechaImpresion = null,
            IntIdUsuario = 36,
            IntIdUsuarioImpresion = null,
            IntIdTipoVentaCotizacion = null,
            ChrCiiuprinRev4 = cotizacionPoliza.ChrCiiuprinRev4?.Length == 5 ? $"0{cotizacionPoliza.ChrCiiuprinRev4}" : $"{cotizacionPoliza.ChrCiiuprinRev4}",
            ChrCiiusecRev4 = null,
            ChrCiiusecIirev4 = null
        }) ;

        cotizacion.SyaCambiosEstadoCotizacions = await _cambiosEstadoSpdService
            .GetCambiosEstadoCotizacion(cotizacionPoliza.CambiosEstadoCotizacion, cotizacion);

        cotizacion.SyaDatosComplementariosCotizacionDomesticas = await _datosCotizacionDomesticaService
            .GetDatosCotizacionDomestica(cotizacionPoliza.DatosComplementariosCotizacionDomesticas, cotizacion);

        cotizacion.SolicitudesCostosCompartidosNav = _solicitudesCostosCompartidoService
            .GetCostosCompartidos(cotizacionPoliza.CostosCompartidos, cotizacion);

        cotizacion.UnidadComercialesNav = await _integracionUnidadesComerciales
            .GetDatosUnidadesComerciales(cotizacion);

        return cotizacion;
    }
}