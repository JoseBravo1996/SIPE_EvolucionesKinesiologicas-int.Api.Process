using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Domain.Entities;
using SIPE_Evolucion.Domain.Enum;

namespace SIPE_Evolucion.Application.Spd.Commands.IntegrarSpd
{
    public class IntegrarSpdRequestHandler : IRequestHandler<IntegrarSpdRequest, IntegrarSpdResponse>
    {
        private readonly IIntegracionCotizacionHistService _cotizacionesHistService;
        private readonly IIntegracionClienteService _clienteSpdService;
        private readonly IIntegracionCotizacionService _cotizacionSpdService;
        private readonly ILogger<IntegrarSpdRequestHandler> _logger;
        private readonly IApplicationDbContext _context;
        public IntegrarSpdRequestHandler(IIntegracionCotizacionHistService cotizacionesHistService, IIntegracionClienteService clienteSpdService,
            IIntegracionCotizacionService cotizacionSpdService, ILogger<IntegrarSpdRequestHandler> logger, IApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _clienteSpdService = clienteSpdService;
            _cotizacionSpdService = cotizacionSpdService;
            _cotizacionesHistService = cotizacionesHistService;
        }

        public async Task<IntegrarSpdResponse> Handle(IntegrarSpdRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Inicio proceso integración Cliente");
            var clienteId = await IntegrarCliente(request, cancellationToken);
            _logger.LogInformation("Fin proceso integración Cliente");
            _logger.LogInformation("Inicio proceso integración cotización");
            var cotizacionIdResult = await IntegrarCotizacion(request, clienteId, cancellationToken);
            _logger.LogInformation("Fin proceso integración cotización");

            return new IntegrarSpdResponse(cotizacionIdResult);
        } 

        private async Task<int> IntegrarCliente(IntegrarSpdRequest request, CancellationToken cancellationToken)
        {
            var personaFisica = request.Cliente.ChrTipoPersona == "F";
            var idProvincia = await GetIdProvincia(request);
            request.Cotizacion.IntIdProvinciaLegal = idProvincia;
            request.Cotizacion.IntIdProvinciaRiesgo = idProvincia;
            var cliente = await _context.ComClientes
                    .Include(x => x.ComDomiciliosClientes).ThenInclude(x => x.IntIdDomicilioNavigation)
                    .Include(x => x.ComClientesHists)
                    .Include(x => x.ComClientesPfisica).ThenInclude(x => x.ComClientesPfisicasHists)
                    .Include(x => x.ComClientesPjuridica).ThenInclude(x => x.ComClientesPjuridicasHists)
                    .FirstOrDefaultAsync(x => x.ChrCuitcuilcdi == request.Cliente.ChrCUITCUILCDI, cancellationToken);
            var clienteId = 0;

            if (cliente is not null)
            {
                clienteId = cliente.IntIdCliente;
                RemoverDomiciliosDescartados(cliente);
                _clienteSpdService.UpdateCliente(request.Cliente, personaFisica, cliente, idProvincia);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                var nuevoCliente = _clienteSpdService.GetNuevoCliente(request.Cliente, personaFisica, idProvincia);
                _context.ComClientes.Add(nuevoCliente);
                await _context.SaveChangesAsync(cancellationToken);
                clienteId = nuevoCliente.IntIdCliente;
            }

            return clienteId;
        }

        private async Task<int> IntegrarCotizacion(IntegrarSpdRequest request, int clienteId, CancellationToken cancellationToken)
        {
            var unidadComercial = await _context.ComUnidadesComerciales.FirstOrDefaultAsync(x =>
                x.VarIdUnidadComercialCrm == request.Cotizacion.IntIdUnidadComercial.ToString(), cancellationToken);
            var nuevaCotizacion = new SyaCotizacion();

            if (unidadComercial is not null)
            {
                if (request.Cotizacion.CotizacionOrigenId != (int)CotizacionOrigen.WebPasMigración &&
                request.Cotizacion.CotizacionOrigenId != (int)CotizacionOrigen.PolizaMigracion)
                {
                    nuevaCotizacion = await _cotizacionSpdService.CreateCotizacion(request.Cotizacion, unidadComercial, clienteId);
                    await _context.SyaCotizaciones.AddAsync(nuevaCotizacion, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    await IntegrarCotizacionHist(nuevaCotizacion, cancellationToken);
                } else
                {
                    throw new NotImplementedException("Actualizacion de Cotizacion");
                }
                
            }
            else
            {
                throw new Exception("Unidad Comercial Inexistente");
            }

            return nuevaCotizacion.IntNroCotizacion;
        }

        private async Task IntegrarCotizacionHist(SyaCotizacion cotizacion, CancellationToken cancellationToken)
        {
            var cotizacionHist = await _cotizacionesHistService.CreateCotizacionHist(cotizacion);
            await _context.SyaCotizacionesHists.AddAsync(cotizacionHist, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private void RemoverDomiciliosDescartados(ComCliente cliente)
        {
            var domiciliosDescartados = cliente.ComDomiciliosClientes.Where(x => 
                x.IntIdTipoDomicilio == 1 || x.IntIdTipoDomicilio == 2);

            foreach (var domicilio in domiciliosDescartados)
            {
                cliente.ComDomiciliosClientes.Remove(domicilio);
            }
            _context.ComDomiciliosClientes.RemoveRange(domiciliosDescartados);
        }

        private async Task<int> GetIdProvincia(IntegrarSpdRequest request)
        {
            var codigoAfip = request.Cliente.Domicilio.IntIdProvDesnormalizada;
            var codigoAfipStr = codigoAfip < 10 ? $"0{codigoAfip}" : $"{codigoAfip}";
            var provincia = await _context.GenProvincias.FirstAsync(x => x.ChrCodigoProvincia == codigoAfipStr);

            return provincia.IntIdProvincia;
        }
    }
}