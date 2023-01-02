using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Common.Interfaces
{
    public interface IIntegracionCotizacionHistService
    {
        Task<SyaCotizacionesHist> CreateCotizacionHist(SyaCotizacion cotizacion);
    }
}
