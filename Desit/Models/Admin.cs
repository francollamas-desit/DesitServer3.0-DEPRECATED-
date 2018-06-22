using System;
using System.Collections.Generic;

namespace Desit.Models
{
    public partial class Admin
    {
        public Admin()
        {
            AdminLog = new HashSet<AdminLog>();
        }

        public string AdminNombre { get; set; }
        public string Contrasenia { get; set; }

        public ICollection<AdminLog> AdminLog { get; set; }
    }
}
