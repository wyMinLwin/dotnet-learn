using System;
using System.Linq.Expressions;
namespace REPOSITORY.Repositories.IRepositories
{
	public interface IGenericRepository<T> where T: class
	{
		Task<IEnumerable<T>> GetAll();
		Task<T?> GetById(int id);
		Task Add(T entity);
		Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);
		void Update(T entity);
		void Delete(T entity);
	}
}