namespace SIPE_Evolucion.Application.Common.Interfaces
{
    public interface IWrapperResponse
    {
        List<string> Messages { get; set; }

        bool Succeeded { get; set; }
    }

    public interface IResponse<out T> : IWrapperResponse
    {
        T Data { get; }
    }
}
