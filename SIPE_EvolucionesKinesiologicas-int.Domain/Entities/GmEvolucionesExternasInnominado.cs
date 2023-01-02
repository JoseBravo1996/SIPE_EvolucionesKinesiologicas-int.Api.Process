using PISCYS.Domain.Constants;

namespace SIPE_Evolucion.Domain.Entities
{
    public class GmEvolucionesExternasInnominado
    {
        public int Id { get; set; }
        public string NroDocumento { get; set; }
        public int DocumentoTipoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
    }
}
