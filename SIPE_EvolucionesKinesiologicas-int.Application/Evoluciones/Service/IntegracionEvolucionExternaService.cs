using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIPE_Evolucion.Application.Common.Exceptions;
using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Application.Common.Wrapper;
using SIPE_Evolucion.Application.Evoluciones.DTO;
using SIPE_Evolucion.Domain.Entities;
using System.Transactions;

namespace SIPE_Evolucion.Application.Evoluciones.Service
{
    public class IntegracionEvolucionExternaService: IIntegracionEvolucionExternaService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<IntegracionEvolucionExternaService> _logger;
        private readonly ISipeDbContext _sipeContext;
        public IntegracionEvolucionExternaService(IApplicationDbContext context, ISipeDbContext sipeContext, ILogger<IntegracionEvolucionExternaService> logger)
        {
            _context = context;
            _sipeContext = sipeContext;
            _logger = logger;
        }
        public async Task<int> GetIdPrestador(string cuil) => await Task.FromResult(_context.Prestadores.FirstOrDefault(w => w.Cuil == cuil)?.Id ?? 0);

        public async Task<Response<int>> Create(GmEvolucionesExternas evolucionExterna, int evolucionMedicaId, string Cuil , GmEvolucionesExternasInnominado trabajador)
        {
            try
            {
                evolucionExterna.PrestadorId = await GetIdPrestador(Cuil);
                evolucionExterna.datFechaDiagnostico = DateTime.Now;
                using var _transaction = await _context.dbFacade.BeginTransactionAsync();
                
                try
                {
                    if (evolucionExterna.NroSiniestro == 0 && evolucionExterna.NroDenuncia == 0)
                    {
                        evolucionExterna.NroDenuncia = null;
                        evolucionExterna.NroSiniestro = null;
                        evolucionExterna.DelegacionOrigenId = null;
                        await _context.GmEvolucionesExternas.AddAsync(evolucionExterna);
                        await _context.SaveChangesAsync();
                        trabajador.Id = evolucionExterna.Id;
                        await _context.GmEvolucionesExternasInnominado.AddAsync(trabajador);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        await _context.GmEvolucionesExternas.AddAsync(evolucionExterna);
                        int saved = await _context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(InnerException.GetInnerException(ex)?.Message);
                    _transaction.Rollback();
                    return await Response<int>.FailAsync($"No se logró guardar la evolución externa.\n{ex.Message}");
                }

                try
                {  
                    GmEvolucionesExternasIntermedia gmEvolucionesExternasIntermedia = new GmEvolucionesExternasIntermedia
                    {
                        EvolucionMedicaDboId = evolucionMedicaId,
                        intIdEvolucionExterna = evolucionExterna.Id
                    };
                    await _sipeContext.GmEvolucionesExternasIntermedia.AddAsync(gmEvolucionesExternasIntermedia);
                    int sipeSaved = await _sipeContext.SaveChangesAsync();
                    _transaction.Commit();
                }
                catch (Exception ex)
                {
                    _logger.LogError(InnerException.GetInnerException(ex)?.Message);
                    _transaction.Rollback();
                    return await Response<int>.FailAsync($"No se logró guardar la evolución externa.\n{ex.Message}");
                }

                return await Response<int>.SuccessAsync("Saved");
            }
            catch (Exception ex)
            {
                _logger.LogError(InnerException.GetInnerException(ex)?.Message);
                return await Response<int>.FailAsync($"No se logró guardar la evolución externa.\n{ex.Message}");
            }
        }
    }
}
