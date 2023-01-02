namespace SIPE_Evolucion.Domain.Entities
{
    public partial class ComClientesPjuridica
    {
        public ComClientesPjuridica()
        {
            ComClientesPjuridicasHists = new HashSet<ComClientesPjuridicasHist>();
        }

        public int IntIdCliente { get; set; }
        public string? VarRazonSocial { get; set; }
        public DateTime? DatFechaConstitucion { get; set; }
        public string? VarProtocoloNotarial { get; set; }
        public string? VarNumeroInscripcion { get; set; }
        public int? IntIdRegistro { get; set; }
        public string? VarIibb { get; set; }

        public virtual ComCliente IntIdClienteNavigation { get; set; } = null!;
        public virtual ICollection<ComClientesPjuridicasHist> ComClientesPjuridicasHists { get; set; }
    }
}
