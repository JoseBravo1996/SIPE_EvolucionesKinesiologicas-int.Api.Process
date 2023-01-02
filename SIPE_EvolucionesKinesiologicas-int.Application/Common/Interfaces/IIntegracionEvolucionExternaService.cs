using SIPE_Evolucion.Application.Common.Wrapper;
using SIPE_Evolucion.Application.Evoluciones.DTO;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Common.Interfaces
{
    public interface IIntegracionEvolucionExternaService
    {
        Task<Response<int>> Create(GmEvolucionesExternas evolucion, int evolucionMedicaId, string Cuil, GmEvolucionesExternasInnominado trabajador);
    }
}
