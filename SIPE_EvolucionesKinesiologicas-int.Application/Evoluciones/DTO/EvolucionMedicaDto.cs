namespace SIPE_Evolucion.Application.Evoluciones.DTO
{
    public class EvolucionMedicaDto
    {
        public string ManoHabil { get; set; }
        public DateTime? FechaAltaMedica { get; set; }
        public DateTime? FechaProximoControl { get; set; }
        public string? EvolucionDescripcion { get; set; }
        public int AtencionTipoId { get; set; }
        public bool NecesitaTraslado { get; set; }
        public int MedicoId { get; set; }
        public DateTime FechaEvolucion { get; set; }
        public string Diagnostico { get; set; }
        public int SiniestroTipoId { get; set; }
        public int ZonaAfectadaId { get; set; }
        public int AgenteMaterialId { get; set; }
        public int NaturalezaLesionId { get; set; }
        public string SiniestroDescripcion { get; set; }
        public int? SiniestroId { get; set; }
        public int? TrabajadorId { get; set; }
        public bool EsNominado { get; set; }
        public int EvolucionEstadoId { get; set; }
        public string UsuarioId { get; set; }
        public int? RechazoMotivoId { get; set; }
        public string? ObservacionesRechazo { get; set; }
        public string? EmpleadorRazonSocial { get; set; }
        public DateTime? FechaAccidente { get; set; }
        public int? EmpleadorId { get; set; }
    }
}
