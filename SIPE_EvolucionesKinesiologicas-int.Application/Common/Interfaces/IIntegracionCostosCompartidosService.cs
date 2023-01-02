using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Common.Interfaces;

public interface IIntegracionCostosCompartidosService
{
    List<SyaSolicitudesCostosCompartido> GetCostosCompartidos(List<SolicitudesCostosCompartidoPoliza> costosCompartidos, SyaCotizacion cotizacion);
}