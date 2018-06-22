using Desit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desit.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(DataContext db, T entity);
        Task<bool> Delete(T entity);
    }
}
