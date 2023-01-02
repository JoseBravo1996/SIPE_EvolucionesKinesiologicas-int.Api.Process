using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Domain.Entities;
using SIPE_Evolucion.Domain.Enum;

namespace SIPE_Evolucion.Application.Spd.Service;

public  class IntegracionCambiosEstadoCotizacionService : IIntegracionCambiosEstadoCotizacionService
{
    private readonly Dictionary<int, TarifaTipos> TarifaPolizaTarifaSya = new()
    {
            { 1,TarifaTipos.TarifaSSN },
            { 2,TarifaTipos.TarifaComercial },
            { 3,TarifaTipos.TarifaComercial },
            { 4,TarifaTipos.TarifaComercial },
            { 5,TarifaTipos.TarifaComercial },
            { 6,TarifaTipos.UltimasTarifas },
            { 7,TarifaTipos.TarifaSugerida },
            { 8,TarifaTipos.TarifaCompetencia },
            { 9,TarifaTipos.TarifaSugerida },
            { 10,TarifaTipos.TarifaComercial },
            { 11,TarifaTipos.TarifaSugerida },
        };

    public async Task<List<SyaCambiosEstadoCotizacion>> GetCambiosEstadoCotizacion(List<CambiosEstadoCotizacionPoliza> cambiosEstadoPoliza, SyaCotizacion cotizacion)
    {
        return await Task.Run(() => {
            var result = new List<SyaCambiosEstadoCotizacion>();
            foreach (var cep in cambiosEstadoPoliza)
            {
                int tipoTarifaId = cep.IntIdTipoTarifa ?? default(int);
                var cambioEstado = new SyaCambiosEstadoCotizacion()
                {
                    IntNroCotizacionNavigation = cotizacion,
                    DatFechaCambio = cep.DatFechaCambio,
                    IntIdUsuario = 36,
                    MonFijo = cep.MonFijo,
                    DecVar = cep.DecVar,
                    MonCxT = cep.MonCxT,
                    MonMensual = cep.MonMensual,
                    MonAnual = cep.MonAnual,
                    MonSugFijo = cep.MonSugFijo,
                    DecSugVar = cep.DecSugVar,
                    MonSugCxT = cep.MonSugCxT,
                    MonSugMensual = cep.MonSugMensual,
                    MonSugAnual = cep.MonSugAnual,
                    MonSsnfijo = cep.MonSsnfijo,
                    DecSsnvar = cep.DecSsnvar,
                    MonSsncxT = cep.MonSsncxT,
                    MonSsnmensual = cep.MonSsnmensual,
                    MonSsnanual = cep.MonSsnanual,
                    MonComFijo = cep.MonComFijo,
                    DecComVar = cep.DecComVar,
                    MonComCxT = cep.MonComCxT,
                    MonComMensual = cep.MonComMensual,
                    MonComAnual = cep.MonComAnual,
                    MonPpfijo = 0,
                    DecPpvar = 0,
                    MonPpcxT = 0,
                    MonPpmensual = 0,
                    MonPpanual = 0,
                    MonCalFijo = 0,
                    DecCalVar = 0,
                    MonCalCxT = 0,
                    MonCalMensual = 0,
                    MonCalAnual = 0,
                    BitPausaEtp = false,
                    IntIdTipoTarifa = (int)TarifaPolizaTarifaSya[cep.IntIdTipoTarifa ?? throw new Exception()],
                    IntIdEstado = (int)EstadosCotizacion.Aprobada
                };
                result.Add(cambioEstado);
            }
            return result;
        });
    }
}