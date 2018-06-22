using System;
using System.Collections.Generic;

namespace Desit.Models
{
    public partial class AdminLog
    {
        public int AdminLogId { get; set; }
        public DateTime Fecha { get; set; }
        public string AdminNombre { get; set; }
        public int AdminLogTipoId { get; set; }

        public AdminLogTipo AdminLogTipo { get; set; }
        public Admin AdminNombreNavigation { get; set; }
    }
}
