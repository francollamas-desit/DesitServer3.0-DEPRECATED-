using System;
using System.Collections.Generic;

namespace Desit.Models
{
    public partial class Barrio
    {
        public Barrio()
        {
            Central = new HashSet<Central>();
        }

        public int BarrioId { get; set; }
        public string Nombre { get; set; }

        public ICollection<Central> Central { get; set; }
    }
}
