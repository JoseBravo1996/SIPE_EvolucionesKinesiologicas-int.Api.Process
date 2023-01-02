using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Common.Interfaces
{
    public interface IIntegracionClienteService
    {
        ComCliente GetNuevoCliente(ClientePoliza clientePoliza, bool personaFisica, int idProvincia);
        void UpdateCliente(ClientePoliza clientePoliza, bool personaFisica, ComCliente cliente, int idProvincia);
    }
}
