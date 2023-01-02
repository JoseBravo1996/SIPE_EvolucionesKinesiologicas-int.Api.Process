using PISCYS.Domain.Constants;

namespace SIPE_Evolucion.Domain.Entities
{
    public class GmEvolucionesExternas
    {
        public int Id { get; set; }
        public int? NroDenuncia { get; set; }
        public string Cuil { get; set; }
        public string? Cuit { get; set; }
        public int? DelegacionOrigenId { get; set; }
        public DateTime FechaAccidente { get; set; }
        public string SiniestroDescripcion { get; set; }
        public string? Diagnostico { get; set; }
        public string? EvolucionDescripcion { get; set; }
        public DateTime datFechaDiagnostico { get; set; }
        public DateTime? FechaProximoControl { get; set; }
        public int? SiniestroTipoId { get; set; }
        public int? NaturalezaLesionId { get; set; }
        public string? AgenteMaterialId { get; set; }
        public int? ZonaAfectadaId { get; set; }
        public DateTime? FechaEvolucion { get; set; }
        public string? ManoHabil { get; set; }
        public string? EmpleadorRazonSocial { get; set; }
        public int? NroSiniestro { get; set; }
        public int MedicoId { get; set; }
        public int? PrestadorId { get; set; }
        public int intIdUsuarioAlta { get; set; } = UsuarioPiscys.PiscysBatch;
        public bool? bitInternado { get; set; }
        public bool NecesitaTraslado { get; set; }
        public DateTime? FechaAltaMedica { get; set; }
    }
}
