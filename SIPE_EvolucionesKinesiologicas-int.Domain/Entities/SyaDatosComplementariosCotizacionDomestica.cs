namespace SIPE_Evolucion.Domain.Entities
{
    public partial class SyaDatosComplementariosCotizacionDomestica
    {
        public int IntIdDatosComplementariosCotizacionDomestica { get; set; }
        public int? IntNroCotizacion { get; set; }
        public int? IntCantidadTrabajadores { get; set; }
        public int? IntCategoriaTrabajador { get; set; }

        public virtual SyaCotizacion? IntNroCotizacionNavigation { get; set; }
    }
}
