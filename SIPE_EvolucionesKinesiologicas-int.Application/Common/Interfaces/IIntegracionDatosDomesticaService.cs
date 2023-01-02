using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Common.Interfaces;

public interface IIntegracionDatosDomesticaService
{
    Task<List<SyaDatosComplementariosCotizacionDomestica>> GetDatosCotizacionDomestica(ICollection<DatosCotizacionDomesticaPoliza> datosDomestica, SyaCotizacion cotizacion);
}