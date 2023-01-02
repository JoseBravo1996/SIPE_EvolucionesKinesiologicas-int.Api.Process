using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Spd.Service;

public  class IntegracionCostosCompartidosService : IIntegracionCostosCompartidosService
{
    private readonly IApplicationDbContext _context;
    private readonly IIntegracionCostosCompartidosHistService _costosCompartidosHistService;

    public IntegracionCostosCompartidosService(IApplicationDbContext context, IIntegracionCostosCompartidosHistService costosCompartidosHistService)
    {
        _costosCompartidosHistService = costosCompartidosHistService;
        _context = context;
    }

    public List<SyaSolicitudesCostosCompartido> GetCostosCompartidos(List<SolicitudesCostosCompartidoPoliza> costosCompartidos, SyaCotizacion cotizacion)
    {
        var unidadComercialNumerosRecibidos = costosCompartidos.Select(x => x.IntIdUnidadComercial);
        var unidadesComerciales = new List<ComUnidadesComerciale>();

        if (unidadComercialNumerosRecibidos is not null && unidadComercialNumerosRecibidos.Any())
             unidadesComerciales = GetUnidadesComerciales(unidadComercialNumerosRecibidos);

        var result = new List<SyaSolicitudesCostosCompartido>();
            
        foreach (var costo in costosCompartidos)
        {
            var idUc = 0;
            if(unidadesComerciales is not null)
            {
                idUc = unidadesComerciales.First(x =>
                int.Parse(x.VarIdUnidadComercialCrm) == costo.IntIdUnidadComercial).IntIdUnidadComercial;
            }
            var nuevaSolicitud = new SyaSolicitudesCostosCompartido()
            {
                IntIdUnidadComercial = idUc,
                DatFecha = costo.DatFecha,
                IntIdEstado = costo.IntIdEstado,
                IntIdUsuario = 36,
                VarObservaciones = null,
                SyaCotizacionNav = cotizacion
            };
            nuevaSolicitud.SyaSolicitudesCostosCompartidosHists = _costosCompartidosHistService
                .GetCostosCompartidosHist(nuevaSolicitud, cotizacion);

            result.Add(nuevaSolicitud);
        }
        return result;
    }

    private List<ComUnidadesComerciale> GetUnidadesComerciales(IEnumerable<int> numerosUcRecibidos)
    {
        var idUcs = numerosUcRecibidos.Select(x => x.ToString());
        var unidadesComerciales = _context.ComUnidadesComerciales.Where(x =>
            idUcs.Contains(x.VarIdUnidadComercialCrm)).ToList();

        return  unidadesComerciales;
    }
}