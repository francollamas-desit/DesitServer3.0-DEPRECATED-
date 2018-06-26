using Desit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desit.Services
{
    public class AdminManagerService
    {
        // Admins conectados <socketId, admin>
        private Dictionary<string, Admin> admins;

        private AdminManagerService()
        {
            admins = new Dictionary<string, Admin>();
        }
    }
}
