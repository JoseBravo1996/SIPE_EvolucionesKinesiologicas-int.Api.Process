using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Spd.Queries.GetComCliente
{
    public class GetComClienteResponse
    {
        public ComCliente ComCliente { get; set; }

        public GetComClienteResponse(ComCliente comCliente)
        {
            ComCliente = comCliente;
        }
    }
}