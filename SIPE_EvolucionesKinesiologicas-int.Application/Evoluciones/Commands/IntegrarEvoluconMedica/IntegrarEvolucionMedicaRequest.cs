using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SIPE_Evolucion.Application.Common.Exceptions;
using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Application.Common.Wrapper;
using SIPE_Evolucion.Application.Evoluciones.DTO;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Evoluciones.Commands.IntegrarEvoluconMedica
{
    public class IntegrarEvolucionMedicaRequest: IRequest<Response<int>>
    {
        public EvolucionMedicaDto Evolucion { get; set; }
        public DatoEvolucionExterna DatoEvolucionExterna { get; set; }
        public string Cuil { get; set; }
        public TrabajadorDto Trabajador { get; set; }
    }

    public class IntegrarEvolucionMedicaRequestHandler : IRequestHandler<IntegrarEvolucionMedicaRequest, Response<int>>
    {
        private readonly IIntegracionEvolucionExternaService _integracionEvolucionExternaService;
        private readonly IMapper _mapper;
        private readonly ILogger<IntegrarEvolucionMedicaRequest> _logger;

        public IntegrarEvolucionMedicaRequestHandler(IIntegracionEvolucionExternaService integracionEvolucionExternaService, IMapper mapper, ILogger<IntegrarEvolucionMedicaRequest> logger)
        {
            _integracionEvolucionExternaService = integracionEvolucionExternaService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<int>> Handle(IntegrarEvolucionMedicaRequest request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            string msg = $"No se encontró la evolución externa. ";
            try
            {
                GmEvolucionesExternas evolucionExterna = _mapper.Map<GmEvolucionesExternas>(request.Evolucion);
                evolucionExterna.Cuit = request.DatoEvolucionExterna.Cuit;
                evolucionExterna.Cuil = request.DatoEvolucionExterna.Cuil;
                evolucionExterna.NroSiniestro = request.DatoEvolucionExterna.NroSiniestro;
                evolucionExterna.DelegacionOrigenId = request.DatoEvolucionExterna.DelegacionOrigen;
                evolucionExterna.NroDenuncia = request.DatoEvolucionExterna.NroDenuncia;
                GmEvolucionesExternasInnominado trabajadorInnominado = _mapper.Map<GmEvolucionesExternasInnominado>(request.Trabajador);
                response = await _integracionEvolucionExternaService.Create(evolucionExterna , request.DatoEvolucionExterna.EvolucionMedicaId , request.Cuil, trabajadorInnominado);
            }
            catch (Exception ex)
            {
                _logger.LogError(InnerException.GetInnerException(ex)?.Message);
                response = await Response<int>.FailAsync($"{msg}\n{ex.Message}");
            }
            return response;
        }
    }
}
