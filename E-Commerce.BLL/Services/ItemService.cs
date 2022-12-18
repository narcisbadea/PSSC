using AutoMapper;
using E_Commerce.BLL.DTOs;
using E_Commerce.DAL.Repositoris.Interfaces;
using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly IItemTypeRepository _itemTypeRepository;
    private readonly IMapper _mapper;

    public ItemService(IItemRepository itemRepository, IMapper mapper, IItemTypeRepository itemTypeRepository)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
        _itemTypeRepository = itemTypeRepository;
    }

    public async Task<IEnumerable<ItemResponseDTO>> GetAllItemsAsync()
    {
        var result = await _itemRepository.GetAllItemsAsync();
        return _mapper.Map<IEnumerable<Item>, IEnumerable<ItemResponseDTO>>(result);
    }

    public async Task InsertItemAsync(ItemRequestDTO item)
    {
        var itemToAdd = _mapper.Map<Item>(item);
        var type = await _itemTypeRepository.GetTypeByIdAsync(item.TypeId);
        itemToAdd.ItemType = type;
        await _itemRepository.AddItemAsync(itemToAdd);
    }
}
