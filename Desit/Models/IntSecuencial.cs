using System;
using System.Collections.Generic;

namespace Desit.Models
{
    public partial class IntSecuencial
    {
        public int IntSecuencialId { get; set; }
        public int Intervalo { get; set; }
        public int Timeout { get; set; }
        public int Reintentos { get; set; }
    }
}
