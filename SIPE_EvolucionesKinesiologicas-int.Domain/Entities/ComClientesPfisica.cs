namespace SIPE_Evolucion.Domain.Entities
{
    public partial class ComClientesPfisica
    {
        public ComClientesPfisica()
        {
            ComClientesPfisicasHists = new HashSet<ComClientesPfisicasHist>();
        }

        public int IntIdCliente { get; set; }
        public string? VarNombre { get; set; }
        public string? VarApellido { get; set; }
        public string? ChrTipoDocumento { get; set; }
        public string? ChrNroDocumento { get; set; }
        public string? ChrSexo { get; set; }
        public DateTime? DatFechaNacimiento { get; set; }
        public string? VarLugarNacimiento { get; set; }
        public string? ChrCiuo { get; set; }
        public int? IntIdEstadoCivil { get; set; }
        public int? IntIdNacionalidad { get; set; }
        public string? VarOcupacion { get; set; }

        public virtual ComCliente IntIdClienteNavigation { get; set; } = null!;
        public virtual ICollection<ComClientesPfisicasHist> ComClientesPfisicasHists { get; set; }
    }
}
