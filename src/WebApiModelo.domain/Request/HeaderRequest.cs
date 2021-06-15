using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiModelo.domain.Request
{
    public class HeaderRequest
    {
        /// <summary>
        /// CorrelationId (GUID) para realizar Log e cache de chamadas
        /// </summary>
        /// <example>a5745ff7-c9e3-4ef2-84e9-3cdfdc3b33f9</example>
        //[Required]
        public string Authorization { get; set; }
    }
}