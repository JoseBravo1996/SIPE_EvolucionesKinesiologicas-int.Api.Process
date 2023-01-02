using MediatR;
using SIPE_Evolucion.Application.Spd.Commands.IntegrarSpd;

namespace SIPE_Evolucion.Application.Spd.DTO
{
    public class IntegrarSpdRequest : IRequest<IntegrarSpdResponse>
    {
        public IntegrarSpdRequest()
        {
            Cliente = new ClientePoliza();
            Cotizacion = new CotizacionPoliza();
        }
        public ClientePoliza Cliente { get; set; }
        public CotizacionPoliza Cotizacion { get; set; }
    }
}
