namespace SIPE_Evolucion.Domain.Entities
{
    public partial class SyaCotizacionUnidadComercial
    {
        public int IntNroCotizacion { get; set; }
        public int IntIdUnidadComercial { get; set; }
        public DateTime DatFechaIncorporacion { get; set; }

        public virtual SyaCotizacion? SyaCotizacionNav { get; set; }
    }
}
