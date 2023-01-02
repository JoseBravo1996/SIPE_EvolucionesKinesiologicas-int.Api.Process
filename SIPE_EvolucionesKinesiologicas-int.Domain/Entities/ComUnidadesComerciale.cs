namespace SIPE_Evolucion.Domain.Entities;

public partial class ComUnidadesComerciale
{
    public int IntIdUnidadComercial { get; set; }
    public int? IntIdDelegacion { get; set; }
    public DateTime? DatFechaVigenciaHasta { get; set; }
    public DateTime? DatFechaEliminacion { get; set; }
    public string VarIdUnidadComercialCrm { get; set; } = null!;
    public string? VarLoginEc { get; set; }
    public bool? BitUcdirecta { get; set; }
}