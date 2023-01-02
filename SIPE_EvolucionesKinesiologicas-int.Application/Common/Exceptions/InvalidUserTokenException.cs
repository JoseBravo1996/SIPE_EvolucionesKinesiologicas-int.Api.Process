﻿using System.Runtime.Serialization;

namespace SIPE_Evolucion.Application.Common.Exceptions
{
    [Serializable]
    public class InvalidUserTokenException : Exception
    {
        public InvalidUserTokenException() : base() { }
        public InvalidUserTokenException(string message) : base(message) { }
        public InvalidUserTokenException(string message, Exception inner) : base(message, inner) { }
        protected InvalidUserTokenException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
