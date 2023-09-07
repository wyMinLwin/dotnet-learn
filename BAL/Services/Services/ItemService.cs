using System;
using BAL.Services.IServices;
using AutoMapper;
using MODEL.DTOs.ItemDtos;
using MODEL.Entities;
using REPOSITORY.UnitOfWork;
using Azure.Core;

namespace BAL.Services.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ItemService (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDTO>> GetItems()
        {
            var items = await _unitOfWork.Item.GetAll();
            var itemsDto = _mapper.Map<IEnumerable<ItemDTO>>(items);
            return itemsDto;
        }

        public async Task<ItemDTO> GetItemById (int id)
        {
            var item = await _unitOfWork.Item.GetById(id);
            var itemDto = _mapper.Map<ItemDTO>(item);
            return itemDto;
        }

        public async Task AddItem (CreateItemDTO request)
        {
            await _unitOfWork.Item.Add(_mapper.Map<Item>(request));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateItem (UpdateItemDTO request, int id)
        {
            var foundItem = await _unitOfWork.Item.GetById(id);
            if (foundItem == null)
            {
                throw new Exception();
            }
            foundItem.Name = request.Name;
            foundItem.Code = request.Code;
            foundItem.Price = request.Price;
            _unitOfWork.Item.Update(foundItem);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteItem (int id)
        {
            var foundItem = await _unitOfWork.Item.GetById(id);
            if (foundItem == null)
            {
                throw new Exception();
            }
            _unitOfWork.Item.Delete(foundItem);
            await _unitOfWork.SaveChangesAsync();

        }
    }
}

