using System;
using System.Collections.Generic;

namespace Desit.Models
{
    public partial class Central
    {
        public Central()
        {
            CentralLog = new HashSet<CentralLog>();
        }

        public string CentralId { get; set; }
        public string Contrasenia { get; set; }
        public int BarrioId { get; set; }

        public Barrio Barrio { get; set; }
        public ICollection<CentralLog> CentralLog { get; set; }
    }
}
