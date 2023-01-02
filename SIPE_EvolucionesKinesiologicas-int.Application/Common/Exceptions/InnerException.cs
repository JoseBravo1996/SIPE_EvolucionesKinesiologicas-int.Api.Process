
namespace SIPE_Evolucion.Application.Common.Exceptions
{
    public static class InnerException
    {
        public static Exception GetInnerException(Exception ex)
        {
            if (ex.InnerException != null)
                ex = GetInnerException(ex.InnerException);

            return ex;
        }
    }
}
