using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly DbContext _rentalContext;
        private readonly DbSet<T> _dbSet;


        public RepositoryBase(DbContext rentalContext)
        {
            _rentalContext = rentalContext;
            _dbSet = _rentalContext.Set<T>();
        }

        public void Add(T entity) => _dbSet.Add(entity);
        
        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task SaveChangesAsync()
        {
            await _rentalContext.SaveChangesAsync();
        }

        public T GetById(int id) => _dbSet.Find(id);

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public IEnumerable<T> GetAll() => _dbSet.AsEnumerable();

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where) => _dbSet.Where(@where).AsEnumerable();

        public bool SaveChanges() => _rentalContext.SaveChanges() >= 0;

        public T Get(Expression<Func<T, bool>> where) => _dbSet.Where(@where).FirstOrDefault();

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _rentalContext.Entry(entity).State = EntityState.Modified;
        }
        
        public void Delete(Expression<Func<T, bool>> where)
        {
            var objects = _dbSet.Where(where).AsEnumerable();
            foreach (var obj in objects)
                _dbSet.Remove(obj);
        }
    }
}