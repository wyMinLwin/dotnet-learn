using System;
using Microsoft.EntityFrameworkCore;
using REPOSITORY.Repositories.IRepositories;
using System.Linq.Expressions;
namespace REPOSITORY.Repositories.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T,bool>> expression)
        {
            var entities =  _entities.Where(expression);
            if (entities == null)
            {
                throw new Exception();
            }
            return await Task.FromResult(entities.ToList());
        }
    }
}

