using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Spd.Service;

public  class IntegracionDatosDomesticaService : IIntegracionDatosDomesticaService
{
    public async Task<List<SyaDatosComplementariosCotizacionDomestica>> GetDatosCotizacionDomestica(ICollection<DatosCotizacionDomesticaPoliza> datosDomestica, SyaCotizacion cotizacion)
    {
        return await Task.Run(() =>
        {
            var result = new List<SyaDatosComplementariosCotizacionDomestica>();
            foreach (var dm in datosDomestica)
            {
                result.Add(new SyaDatosComplementariosCotizacionDomestica()
                {
                    IntCantidadTrabajadores = dm.IntCantidadTrabajadores,
                    IntCategoriaTrabajador = dm.IntCategoriaTrabajador,
                    IntNroCotizacionNavigation = cotizacion,
                });
            }
            return result;
        });
    }
}