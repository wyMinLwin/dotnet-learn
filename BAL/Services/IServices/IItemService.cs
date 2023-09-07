using System;
using MODEL.DTOs.ItemDtos;
namespace BAL.Services.IServices
{
	public interface IItemService
	{
		Task<IEnumerable<ItemDTO>> GetItems();
		Task<ItemDTO> GetItemById(int id);
		Task AddItem(CreateItemDTO request);
		Task UpdateItem(UpdateItemDTO request,int id);
		Task DeleteItem(int id);
	}
}

