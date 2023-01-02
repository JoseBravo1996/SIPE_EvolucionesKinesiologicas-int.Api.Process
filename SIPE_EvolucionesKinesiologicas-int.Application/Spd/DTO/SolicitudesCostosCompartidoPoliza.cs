using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Spd.DTO;
public class SolicitudesCostosCompartidoPoliza
{
    public int IntIdSolicitudCostosCompartidos { get; set; }
    public DateTime DatFecha { get; set; }
    public int IntNroCotizacion { get; set; }
    public int IntIdUnidadComercial { get; set; }
    public int IntIdEstado { get; set; }
    public string? VarObservaciones { get; set; }
}