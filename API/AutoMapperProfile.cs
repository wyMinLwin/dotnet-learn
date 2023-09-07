using System;
using MODEL.DTOs.ItemDtos;
using MODEL.Entities;
using AutoMapper;
namespace API
{
	public class AutoMapperProfile:Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<ItemDTO, Item>();
            CreateMap<Item, ItemDTO>();
			CreateMap<CreateItemDTO, Item>();
        }
    }
}

