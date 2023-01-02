using Microsoft.AspNetCore.Mvc;
using SIPE_Evolucion.Application.Common.Wrapper;
using SIPE_Evolucion.Application.Evoluciones.Commands.IntegrarEvoluconMedica;

namespace SIPE_Evolucion.Api.Process.Controllers
{
    public class PISCYSController: ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Response<int>> CreateEvolucionMedica(IntegrarEvolucionMedicaRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
