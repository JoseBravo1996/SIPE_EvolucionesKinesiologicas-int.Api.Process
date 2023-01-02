namespace SIPE_Evolucion.Domain.Entities
{
    public partial class ComClientesPjuridicasHist
    {
        public int IntIdClientePjuridicaHist { get; set; }
        public int IntIdCliente { get; set; }
        public int IntIdClienteHist { get; set; }
        public string? VarRazonSocial { get; set; }
        public DateTime? DatFechaConstitucion { get; set; }
        public string? VarProtocoloNotarial { get; set; }
        public string? VarNumeroInscripcion { get; set; }
        public int? IntIdRegistro { get; set; }
        public string? VarIibb { get; set; }

        public virtual ComClientesHist IntIdClienteHistNavigation { get; set; } = null!;
        public virtual ComClientesPjuridica IntIdClienteNavigation { get; set; } = null!;
    }
}
