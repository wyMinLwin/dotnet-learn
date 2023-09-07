using System;
using REPOSITORY.Repositories.IRepositories;
namespace REPOSITORY.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		IItemRepository Item { get; }
        Task<int> SaveChangesAsync();
    }
}

