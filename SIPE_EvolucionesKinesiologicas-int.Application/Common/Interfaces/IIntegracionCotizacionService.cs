using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Common.Interfaces
{
    public interface IIntegracionCotizacionService
    {
        Task<SyaCotizacion> CreateCotizacion(CotizacionPoliza cotizacionPoliza, ComUnidadesComerciale unidadComercial, int clienteId);
    }
}
