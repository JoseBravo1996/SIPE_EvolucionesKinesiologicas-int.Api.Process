namespace SIPE_Evolucion.Application.Spd.DTO
{
    public class CotizacionPoliza
    {
        public CotizacionPoliza()
        {
            CambiosEstadoCotizacion = new List<CambiosEstadoCotizacionPoliza>();
            DatosComplementariosCotizacionDomesticas = new List<DatosCotizacionDomesticaPoliza>();
            CostosCompartidos = new List<SolicitudesCostosCompartidoPoliza>();
        }
        public int CotizacionOrigenId { get; set; }
        public int IntIdCotizacionReingenieria { get; set; }
        public DateTime DatCreado { get; set; }
        public int IntTrabajadores { get; set; }
        public decimal MonMasaSalarial { get; set; }
        public int IntIdProvinciaLegal { get; set; }
        public int IntIdProvinciaRiesgo { get; set; }
        public int IntNivelRiesgo { get; set; }
        public int IntIdUnidadComercial { get; set; }
        public int IntIdDelegacion { get; set; }
        public DateTime DatFechaEstado { get; set; }
        public int? IntCodigoArt { get; set; }
        public string ChrCiiuprin { get; set; } = null!;
        public string ChrCiiuprinN { get; set; } = null!;
        public string? VarActividadEspec { get; set; }
        public decimal? MonCmpFijo { get; set; }
        public decimal? DecCmpVar { get; set; }
        public decimal? MonCmpCxT { get; set; }
        public decimal? MonCmpMensual { get; set; }
        public decimal? MonCmpAnual { get; set; }
        public bool BitTraspaso { get; set; }
        public string? VarNombre { get; set; }
        public string? VarApellido { get; set; }
        public string? VarRazonSocial { get; set; }
        public string? ChrCiiuprinRev4 { get; set; }
        public string? ChrCiiusecIirev4 { get; set; }


        public virtual List<CambiosEstadoCotizacionPoliza> CambiosEstadoCotizacion { get; set; }
        public virtual List<DatosCotizacionDomesticaPoliza> DatosComplementariosCotizacionDomesticas { get; set; }
        public virtual List<SolicitudesCostosCompartidoPoliza> CostosCompartidos { get; set; }
    }
}
