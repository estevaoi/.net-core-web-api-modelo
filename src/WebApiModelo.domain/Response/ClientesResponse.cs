using System;

namespace WebApiModelo.domain.Response
{
    public class ClientesResponse
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public bool Situacao { get; set; }
    }
}