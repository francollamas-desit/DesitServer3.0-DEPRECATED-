using Desit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desit.Repositories
{
    public class IntSecuencialRepo : Repository<IntSecuencial>
    {

        public IntSecuencialRepo()
        {

        }

        public async Task<IntSecuencial> Get()
        {
            using (DataContext db = new DataContext())
            {
                return await db.IntSecuencial.ToAsyncEnumerable().FirstOrDefault();
            }
        }
        
    }

}
