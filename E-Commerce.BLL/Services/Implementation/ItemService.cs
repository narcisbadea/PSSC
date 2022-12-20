using AutoMapper;
using E_Commerce.BLL.DTOs;
using E_Commerce.BLL.Services.Interfaces;
using E_Commerce.DAL.Repositoris.Interfaces;
using E_Commerce.Domain.Models;

namespace E_Commerce.BLL.Services.Implementation;

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
        if(result is null)
        {
            return new List<ItemResponseDTO>();
        }
        return _mapper.Map<IEnumerable<Item>, IEnumerable<ItemResponseDTO>>(result);
    }

    public async Task InsertItemAsync(ItemRequestDTO item)
    {
        var itemToAdd = _mapper.Map<Item>(item);
        var type = await _itemTypeRepository.GetTypeByIdAsync(item.TypeId);
        if (type is not null)
        {
            itemToAdd.ItemType = type;
            await _itemRepository.AddItemAsync(itemToAdd);
        }
    }
}
