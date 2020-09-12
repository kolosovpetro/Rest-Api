using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        bool SaveChanges();
        Task SaveChangesAsync();
        T GetById(int id);
        T Get(Expression<Func<T, bool>> where);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
    }
}