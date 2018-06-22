using System;
using System.Collections.Generic;

namespace Desit.Models
{
    public partial class CentralLogTipo
    {
        public CentralLogTipo()
        {
            CentralLog = new HashSet<CentralLog>();
        }

        public int CentralLogTipoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<CentralLog> CentralLog { get; set; }
    }
}
