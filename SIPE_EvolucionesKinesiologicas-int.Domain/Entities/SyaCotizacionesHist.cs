namespace SIPE_Evolucion.Domain.Entities
{
    public partial class SyaCotizacionesHist
    {
        public int? IntNroCotizacion { get; set; }
        public DateTime? DatCreado { get; set; }
        public int? IntIdCliente { get; set; }
        public int? IntTrabajadores { get; set; }
        public decimal? MonMasaSalarial { get; set; }
        public int? IntIdProvinciaLegal { get; set; }
        public int? IntIdProvinciaRiesgo { get; set; }
        public int? IntNivelRiesgo { get; set; }
        public bool? BitMoroso { get; set; }
        public bool? BitLibreDeuda { get; set; }
        public bool? BitRegularizado { get; set; }
        public int? IntIdUnidadComercial { get; set; }
        public int? IntIdDelegacion { get; set; }
        public int? IntIdUsuario { get; set; }
        public DateTime? DatFechaEstado { get; set; }
        public int? IntIdEstado { get; set; }
        public int? IntCodigoArt { get; set; }
        public string? ChrCiiuprin { get; set; }
        public string? ChrCiiusecun { get; set; }
        public string? ChrCiiuprinN { get; set; }
        public string? ChrCiiusecunIi { get; set; }
        public string? ChrCiiusecunIin { get; set; }
        public string? ChrCiiusecunN { get; set; }
        public string? VarActividadEspec { get; set; }
        public decimal? MonCmpFijo { get; set; }
        public decimal? DecCmpVar { get; set; }
        public decimal? MonCmpCxT { get; set; }
        public decimal? MonCmpMensual { get; set; }
        public decimal? MonCmpAnual { get; set; }
        public int? IntIdContacto { get; set; }
        public int? IntIdDomicilio { get; set; }
        public int? IntCantEstablecimiento { get; set; }
        public int? IntIdSiniestroAgrupado { get; set; }
        public int? IntIdSiniestroProyeccion { get; set; }
        public decimal? MonPromCiiu { get; set; }
        public string ChrTipoCotizacion { get; set; } = null!;
        public int? IntIdMetodo { get; set; }
        public bool? BitTraspaso { get; set; }
        public string? VarNombre { get; set; }
        public string? VarApellido { get; set; }
        public string? VarRazonSocial { get; set; }
        public bool? BitPausaEtp { get; set; }
        public DateTime? DatFechaImpresion { get; set; }
        public int? IntIdUsuarioImpresion { get; set; }
        public DateTime? DatFechaModificacion { get; set; }
        public int? IntIdUsuarioModificacion { get; set; }
        public int? IntIdTipoVentaCotizacion { get; set; }
        public string? ChrCiiuprinRev4 { get; set; }
        public string? ChrCiiusecRev4 { get; set; }
        public string? ChrCiiusecIirev4 { get; set; }
    }
}
