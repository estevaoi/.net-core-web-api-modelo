using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiModelo.comum.ExceptionClass
{
    public class NaoAutorizadoException : Exception
    {
        public NaoAutorizadoException(string mensagem)
            : base(mensagem)
        {
        }
    }
}