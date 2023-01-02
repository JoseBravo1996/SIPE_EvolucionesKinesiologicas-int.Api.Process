using Microsoft.AspNetCore.Mvc;
using SIPE_Evolucion.Application.Spd.Commands.IntegrarSpd;
using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Application.Spd.Queries.GetComCliente;

namespace SIPE_Evolucion.Api.Process.Controllers
{
    public class SpdController : ApiControllerBase
    {
        [HttpGet("GetComCliente/{cuitCuil}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetComClienteResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<string>>> GetComClienteAsync(string cuitCuil)
        {
            var response = await Mediator.Send(new GetComClienteRequest(cuitCuil));
            if (response.ComCliente.IntIdCliente is not 0)
                return Ok(response);
            else
                return NotFound();
        }

        [HttpPost("IntegrarSpd")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IntegrarSpdResponse))]
        public async Task<IActionResult> IntegrarSpdAsync([FromBody] IntegrarSpdRequest request)
        {
            var response = await Mediator.Send(request);
            if (response.SpdNumero != 0)
                return Ok(response);
            else
                return NotFound();
        }
    }
}