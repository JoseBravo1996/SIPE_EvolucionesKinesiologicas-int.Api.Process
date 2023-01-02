namespace SIPE_Evolucion.Domain.Entities
{
    public partial class SyaCambiosEstadoCotizacion
    {
        public int IntIdCambioEstadoCotizacion { get; set; }
        public int IntIdEstado { get; set; }
        public DateTime DatFechaCambio { get; set; }
        public int IntIdUsuario { get; set; }
        public int IntNroCotizacion { get; set; }
        public decimal? MonFijo { get; set; }
        public decimal? DecVar { get; set; }
        public decimal? MonCxT { get; set; }
        public decimal? MonMensual { get; set; }
        public decimal? MonAnual { get; set; }
        public decimal? MonSugFijo { get; set; }
        public decimal? DecSugVar { get; set; }
        public decimal? MonSugCxT { get; set; }
        public decimal? MonSugMensual { get; set; }
        public decimal? MonSugAnual { get; set; }
        public decimal? MonSsnfijo { get; set; }
        public decimal? DecSsnvar { get; set; }
        public decimal? MonSsncxT { get; set; }
        public decimal? MonSsnmensual { get; set; }
        public decimal? MonSsnanual { get; set; }
        public decimal? MonComFijo { get; set; }
        public decimal? DecComVar { get; set; }
        public decimal? MonComCxT { get; set; }
        public decimal? MonComMensual { get; set; }
        public decimal? MonComAnual { get; set; }
        public decimal? MonPpfijo { get; set; }
        public decimal? DecPpvar { get; set; }
        public decimal? MonPpcxT { get; set; }
        public decimal? MonPpmensual { get; set; }
        public decimal? MonPpanual { get; set; }
        public decimal? MonCalFijo { get; set; }
        public decimal? DecCalVar { get; set; }
        public decimal? MonCalCxT { get; set; }
        public decimal? MonCalMensual { get; set; }
        public decimal? MonCalAnual { get; set; }
        public string? VarObservaciones { get; set; }
        public int? IntIdTipoTarifa { get; set; }
        public bool? BitPausaEtp { get; set; }

        public virtual SyaCotizacion IntNroCotizacionNavigation { get; set; } = null!;
    }
}
