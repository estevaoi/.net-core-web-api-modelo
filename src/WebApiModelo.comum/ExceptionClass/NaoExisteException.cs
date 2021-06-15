using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiModelo.comum.ExceptionClass
{
    public class NaoExisteException : Exception
    {
        public NaoExisteException(string mensagem)
            : base(mensagem)
        {
        }
    }
}