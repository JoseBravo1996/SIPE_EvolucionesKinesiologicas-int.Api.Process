namespace SIPE_Evolucion.Application.Spd.Commands.IntegrarSpd
{
    public class IntegrarSpdResponse
    {
        public IntegrarSpdResponse(int spdNumero)
        {
            SpdNumero = spdNumero;
        }

        public int SpdNumero { get; set; }
    }
}