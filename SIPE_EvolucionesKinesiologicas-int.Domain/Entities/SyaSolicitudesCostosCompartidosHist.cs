namespace SIPE_Evolucion.Domain.Entities
{
    public partial class SyaSolicitudesCostosCompartidosHist
    {
        public int IntIdSolicitudCostosCompartidosHist { get; set; }
        public int IntIdSolicitudCostosCompartidos { get; set; }
        public int IntIdUsuario { get; set; }
        public DateTime DatFecha { get; set; }
        public int IntNroCotizacion { get; set; }
        public int IntIdUnidadComercial { get; set; }
        public int IntIdEstado { get; set; }
        public string? VarObservaciones { get; set; }
        public int IntIdUsuarioModif { get; set; }
        public DateTime DatFechaModif { get; set; }

        public virtual SyaCotizacion? SyaCotizacionNav { get; set; }
        public virtual SyaSolicitudesCostosCompartido IntIdSolicitudCostosCompartidosNavigation { get; set; } = null!;
    }
}
