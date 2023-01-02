namespace SIPE_Evolucion.Domain.Entities
{
    public partial class SyaSolicitudesCostosCompartido
    {
        public SyaSolicitudesCostosCompartido()
        {
            SyaSolicitudesCostosCompartidosHists = new HashSet<SyaSolicitudesCostosCompartidosHist>();
        }

        public int IntIdSolicitudCostosCompartidos { get; set; }
        public int IntIdUsuario { get; set; }
        public DateTime DatFecha { get; set; }
        public int IntNroCotizacion { get; set; }
        public int IntIdUnidadComercial { get; set; }
        public int IntIdEstado { get; set; }
        public string? VarObservaciones { get; set; }

        public virtual SyaCotizacion? SyaCotizacionNav { get; set; }
        public virtual ICollection<SyaSolicitudesCostosCompartidosHist> SyaSolicitudesCostosCompartidosHists { get; set; }
    }
}
