using System;

namespace WebApiModelo.domain.Dtos
{
    public class ClientesDto
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public bool Situacao { get; set; }
    }
}