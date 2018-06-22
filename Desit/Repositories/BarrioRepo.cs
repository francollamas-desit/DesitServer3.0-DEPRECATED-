using Desit.Models;
using Desit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desit.Repositories
{
    public class BarrioRepo : Repository<Barrio>
    {
        public BarrioRepo()
        {

        }

        public async Task<Barrio> Get(int id)
        {
            using (DataContext db = new DataContext())
            {
                return await db.Barrio.FindAsync(id);
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (DataContext db = new DataContext())
            {
                return await Delete(db, await db.Barrio.FindAsync(id));
            }
        }

    }
}
