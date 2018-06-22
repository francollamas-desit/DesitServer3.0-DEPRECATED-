using System;
using System.Collections.Generic;

namespace Desit.Models
{
    public partial class CentralLog
    {
        public int CentralLogId { get; set; }
        public DateTime Fecha { get; set; }
        public string CentralId { get; set; }
        public int CentralLogTipoId { get; set; }

        public Central Central { get; set; }
        public CentralLogTipo CentralLogTipo { get; set; }
    }
}
