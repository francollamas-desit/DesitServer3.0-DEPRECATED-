using Desit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desit.Repositories
{
    public class CentralRepo : Repository<Central>
    {

        public CentralRepo()
        {

        }

        public async Task<Central> Get(string id)
        {
            using (DataContext db = new DataContext())
            {
                return await db.Central.FindAsync(id);
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (DataContext db = new DataContext())
            {
                return await Delete(db, await db.Central.FindAsync(id));
            }
        }

        /**
         * Obtiene el estado actual de todas las centrales
         */
        public async Task<IEnumerable<object>> GetEstadoCentrales()
        {
            using (DataContext db = new DataContext())
            {
                // Explicación: se va armando la consulta, hasta que el método ToList() la ejecuta.

                // Union de tablas necesarias
                var union = from l in db.CentralLog
                           join c in db.Central on l.CentralId equals c.CentralId
                           join b in db.Barrio on c.BarrioId equals b.BarrioId
                           select new { Central = c.CentralId, Barrio = b.Nombre, l.Fecha, Estado = l.CentralLogTipoId};

                // Agrupamos y seleccionamos en cada grupo el log con fecha más reciente
                var groups = union.GroupBy(a => a.Central);
                var list = groups.SelectMany(a => a.Where(b => b.Fecha == a.Max(c => c.Fecha)));

                return await list.ToAsyncEnumerable().ToList();
            }
        }

        /**
         * Obtiene todos los estados de una central específica (con límite)
         */
        public async Task<IEnumerable<object>> GetEstadosCentral(string centralId)
        {
            using (DataContext db = new DataContext())
            {
                var res = from l in db.CentralLog
                          where l.CentralId == centralId
                          orderby l.Fecha descending
                          select new { l.Fecha, Estado = l.CentralLogTipoId};

                return await res.Take(20).ToAsyncEnumerable().ToList(); // TODO: valor de límite hardcodeado
            }
        }
    }
}
