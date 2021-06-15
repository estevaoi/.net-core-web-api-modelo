using System;

namespace WebApiModelo.domain.Entities
{
    public class ClientesEntity
    {
        public Guid CLIENTE_ID { get; set; }
        public string NOME { get; set; }
        public string DOCUMENTO { get; set; }
        public bool SITUACAO { get; set; }
    }
}