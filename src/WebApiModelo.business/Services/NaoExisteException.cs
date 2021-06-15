using System;
using System.Runtime.Serialization;

namespace WebApiModelo.business.Services
{
    [Serializable]
    internal class NaoExisteException : Exception
    {
        public NaoExisteException()
        {
        }

        public NaoExisteException(string message) : base(message)
        {
        }

        public NaoExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NaoExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}