using System;
using System.Collections.Generic;

namespace Desit.Models
{
    public partial class AdminLogTipo
    {
        public AdminLogTipo()
        {
            AdminLog = new HashSet<AdminLog>();
        }

        public int AdminLogTipoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<AdminLog> AdminLog { get; set; }
    }
}
