using Desit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desit.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        // Define si es inmutable, es decir, una vez creada una fila, no se puede borrar ni modificar
        protected bool Inmutable { get; set; }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (DataContext db = new DataContext())
            {
                DbSet<T> entities = db.Set<T>();

                return await entities.ToListAsync();
            }
        }
        

        public async Task Insert(T entity)
        {
            using (DataContext db = new DataContext())
            {
                DbSet<T> entities = db.Set<T>();

                if (entity == null)
                {
                    throw new ArgumentNullException("Entidad nula");
                }

                entities.Add(entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> Update(T entity)
        {
            if (Inmutable) return false;

            using (DataContext db = new DataContext())
            {
                DbSet<T> entities = db.Set<T>();

                if (entity == null)
                {
                    throw new ArgumentNullException("Entidad nula");
                }

                db.Entry(entity).State = EntityState.Modified;
                try
                {
                    await db.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }
                
            }
        }

        public async Task<bool> Delete(T entity)
        {
            if (Inmutable) return false;

            using (DataContext db = new DataContext())
            {
                DbSet<T> entities = db.Set<T>();

                if (entity == null)
                {
                    return false;
                }

                entities.Remove(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(DataContext db, T entity)
        {
            if (Inmutable) return false;

            DbSet<T> entities = db.Set<T>();

            if (entity == null)
            {
                return false;
            }

            entities.Remove(entity);
            await db.SaveChangesAsync();
            return true;
        }
    }
}