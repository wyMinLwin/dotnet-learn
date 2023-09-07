using REPOSITORY.Repositories.IRepositories;
using MODEL.Entities;
namespace REPOSITORY.Repositories.Repositories
{
	internal class ItemRepository: GenericRepository<Item>,IItemRepository
	{
		public ItemRepository(DataContext context): base(context)
		{
		}
	}
}

