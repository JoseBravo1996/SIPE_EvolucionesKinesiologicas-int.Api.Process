using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Spd.Service;

public class IntegracionCostosCompartidosHistService : IIntegracionCostosCompartidosHistService
{
    public ICollection<SyaSolicitudesCostosCompartidosHist> GetCostosCompartidosHist(SyaSolicitudesCostosCompartido solicitudCostoCompartido, SyaCotizacion cotizacion)
    {
        var result = new List<SyaSolicitudesCostosCompartidosHist>();
        var nuevoHist = new SyaSolicitudesCostosCompartidosHist()
        {
            IntIdUsuario = solicitudCostoCompartido.IntIdUsuario,
            IntIdUsuarioModif = solicitudCostoCompartido.IntIdUsuario,
            DatFecha = solicitudCostoCompartido.DatFecha,
            IntNroCotizacion = solicitudCostoCompartido.IntNroCotizacion,
            IntIdUnidadComercial = solicitudCostoCompartido.IntIdUnidadComercial,
            IntIdEstado = solicitudCostoCompartido.IntIdEstado,
            VarObservaciones = solicitudCostoCompartido.VarObservaciones,
            DatFechaModif = solicitudCostoCompartido.DatFecha,
            IntIdSolicitudCostosCompartidosNavigation = solicitudCostoCompartido,
            SyaCotizacionNav = cotizacion
        };
        result.Add(nuevoHist);
        return result;
    }
}