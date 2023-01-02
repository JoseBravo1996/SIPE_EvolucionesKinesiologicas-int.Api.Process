using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Spd.Service;

public  class IntegracionCotizacionHistService : IIntegracionCotizacionHistService
{
    public IntegracionCotizacionHistService() { }

    public async Task<SyaCotizacionesHist> CreateCotizacionHist(SyaCotizacion cotizacion)
    {
        var cotizacionHist = await Task.Run(() => new SyaCotizacionesHist()
        {
            IntNroCotizacion = cotizacion.IntNroCotizacion,
            DatCreado = cotizacion.DatCreado,
            IntIdCliente = cotizacion.IntIdCliente,
            IntTrabajadores = cotizacion.IntTrabajadores,
            MonMasaSalarial = cotizacion.MonMasaSalarial,
            IntIdProvinciaLegal = cotizacion.IntIdProvinciaLegal,
            IntIdProvinciaRiesgo = cotizacion.IntIdProvinciaRiesgo,
            IntNivelRiesgo = cotizacion.IntNivelRiesgo,
            IntIdUnidadComercial = cotizacion.IntIdUnidadComercial,
            IntIdDelegacion = cotizacion.IntIdDelegacion,
            IntIdUsuario = 36,
            DatFechaEstado = cotizacion.DatFechaEstado,
            IntIdEstado = 6,
            IntCodigoArt = cotizacion.IntCodigoArt,
            ChrCiiuprin = cotizacion.ChrCiiuprin,
            ChrCiiuprinN = cotizacion.ChrCiiuprinN,
            VarActividadEspec = cotizacion.VarActividadEspec,
            MonCmpFijo = cotizacion.MonCmpFijo,
            DecCmpVar = cotizacion.DecCmpVar,
            MonCmpCxT = cotizacion.MonCmpCxT,
            MonCmpMensual = cotizacion.MonCmpMensual,
            MonCmpAnual = cotizacion.MonCmpAnual,
            ChrTipoCotizacion = "C",
            BitTraspaso = cotizacion.BitTraspaso,
            VarNombre = cotizacion.VarNombre,
            VarApellido = cotizacion.VarApellido,
            VarRazonSocial = cotizacion.VarRazonSocial,
            BitPausaEtp = false,
            BitRegularizado = false,
            ChrCiiuprinRev4 = cotizacion.ChrCiiuprinRev4,
        }) ;

        return cotizacionHist;
    }
}