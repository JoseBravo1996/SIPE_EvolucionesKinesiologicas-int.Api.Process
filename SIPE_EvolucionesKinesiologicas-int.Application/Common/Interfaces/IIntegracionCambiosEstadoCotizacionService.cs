using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Common.Interfaces;

public interface IIntegracionCambiosEstadoCotizacionService
{
    Task<List<SyaCambiosEstadoCotizacion>> GetCambiosEstadoCotizacion(List<CambiosEstadoCotizacionPoliza> cambiosEstadoPoliza, SyaCotizacion cotizacion);
}
