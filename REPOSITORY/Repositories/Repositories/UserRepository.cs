using System;
using MODEL.Entities;
using REPOSITORY.Repositories.IRepositories;
namespace REPOSITORY.Repositories.Repositories
{
	internal class UserRepository:GenericRepository<User>,IUserRepository
	{
		public UserRepository (DataContext dataContext): base(dataContext)
		{

		}
	}
}

