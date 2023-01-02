namespace SIPE_Evolucion.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    { 
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception inner) : base(message, inner) { }
        public NotFoundException(string name, object key)
            : base($"No existe la entidad \"{name}\" ({key}).")
        {
        }
    }
}
