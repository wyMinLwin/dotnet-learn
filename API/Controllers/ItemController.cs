using System;
using Microsoft.AspNetCore.Authorization;
using MODEL.DTOs.ItemDtos;
using BAL.Services.IServices;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
	[ApiController]
	[Authorize]
	[Route("[controller]/api")]
	public class ItemController:ControllerBase
	{
		private readonly IItemService _itemService;

		public ItemController (IItemService itemService)
		{
			_itemService = itemService;
		}

		[HttpGet("GetItems")]
		public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItems ()
		{
			var response = await _itemService.GetItems();
            return Ok(response);
		}

		[HttpGet("GetItemById/{id}")]
		public async Task<ActionResult<ItemDTO>> GetItemById(int id)
		{
			var response = await _itemService.GetItemById(id);
			return Ok(response);
		}

		[HttpPost("AddItem")]
		public async Task<ActionResult > AddItem(CreateItemDTO request)
		{
			await _itemService.AddItem(request);
			return Ok();
		}

		[HttpPut("UpdateItem/{id}")]
		public async Task<ActionResult> UpdateItem(UpdateItemDTO request,int id)
		{
			await _itemService.UpdateItem(request, id);
			return Ok();
		}

		[HttpDelete("DeleteItem/{id}")]
		public async Task<ActionResult> DeleteItem(int id)
		{
			await _itemService.DeleteItem(id);
			return Ok();
		}
	}
}

