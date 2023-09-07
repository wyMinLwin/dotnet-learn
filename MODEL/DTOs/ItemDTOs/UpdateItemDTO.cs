using System;
namespace MODEL.DTOs.ItemDtos
{
	public class UpdateItemDTO
	{
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public int Price { get; set; } = 0;
    }
}

