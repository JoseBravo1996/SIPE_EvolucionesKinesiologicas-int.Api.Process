using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Common.Interfaces;

public interface IIntegracionCostosCompartidosHistService
{
    ICollection<SyaSolicitudesCostosCompartidosHist> GetCostosCompartidosHist(SyaSolicitudesCostosCompartido solicitudCostoCompartido, SyaCotizacion cotizacion);
}