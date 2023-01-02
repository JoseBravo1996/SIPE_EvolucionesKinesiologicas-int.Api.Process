namespace SIPE_Evolucion.Domain.Entities
{
    public class GmEvolucionesExternasHist
    {
        public int IntIdEvolucionHist { get; set; }
        public int? IntIdDenuncia { get; set; }
        public string VarCuil { get; set; }
        public string VarCuit { get; set; }
        public DateTime DatFechaAccidente { get; set; }
        public string VarDescripcionAccidente { get; set; }
        public int? IntIdNaturalezaLesion { get; set; }
        public string ChrIdAgenteCausante { get; set; }
        public int? IntIdZonaAfectada { get; set; }
        public string VarDiagnostico { get; set; }
        public string VarEvolucion { get; set; }
        public DateTime DatFechaDiagnostico { get; set; }
        public DateTime? DatFechaProximoControl { get; set; }
        public int? IntIdTipoSiniestro { get; set; }
        public DateTime DatFechaModificacion { get; set; }
        public int IntIdUsuarioModificacion { get; set; }
        public int? IntIdSeguimientoMed { get; set; }
        public string VarApellido { get; set; }
        public string VarNombre { get; set; }
        public string VarRazonSocial { get; set; }
        public int IntIdEstado { get; set; }
        public string VarMotivoRechazo { get; set; }
        public int IntIdMedico { get; set; }
        public int IntIdPrestador { get; set; }
        public int IntIdUsuarioAlta { get; set; }
        public int IntIdEvolucionExterna { get; set; }
        public DateTime DatFechaAlta { get; set; }
        public bool? BitInternado { get; set; }
        public bool BitTraslado { get; set; }
        public int? IntIdMotivoRechazo { get; set; }
        public DateTime? DatFechaAltaMedica { get; set; }
    }
}
