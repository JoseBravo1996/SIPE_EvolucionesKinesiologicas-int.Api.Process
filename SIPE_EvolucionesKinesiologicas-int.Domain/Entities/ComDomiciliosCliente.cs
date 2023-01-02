namespace SIPE_Evolucion.Domain.Entities
{
    public partial class ComDomiciliosCliente
    {
        public int IntIdCliente { get; set; }
        public int IntIdDomicilio { get; set; }
        public int IntIdTipoDomicilio { get; set; }

        public virtual ComCliente IntIdClienteNavigation { get; set; } = null!;
        public virtual GenDomicilio IntIdDomicilioNavigation { get; set; } = null!;
    }
}
