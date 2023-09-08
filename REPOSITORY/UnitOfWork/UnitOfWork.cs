using System;
using REPOSITORY.Repositories.Repositories;
using REPOSITORY.Repositories.IRepositories;
namespace REPOSITORY.UnitOfWork
{
	public class UnitOfWork: IUnitOfWork
	{
		private DataContext _dataContext;

		public UnitOfWork (DataContext dataContext)
		{
			_dataContext = dataContext;
			Item = new ItemRepository(_dataContext);
            User = new UserRepository(_dataContext); 
		}

        public IItemRepository Item { get; private set; }
        public IUserRepository User { get; private set; }

        public void Dispose() 
        {
            _dataContext.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}

