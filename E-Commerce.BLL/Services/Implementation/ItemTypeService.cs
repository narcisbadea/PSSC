using AutoMapper;

using E_Commerce.BLL.Services.Interfaces;
using E_Commerce.DAL.Repositoris.Interfaces;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.BLL.Services.Implementation;

public class ItemTypeService : IItemTypeService
{
    private readonly IItemTypeRepository _itemTypeRepository;
    private readonly IMapper _mapper;

    public ItemTypeService(IItemTypeRepository itemTypeRepository, IMapper mapper)
    {
        _itemTypeRepository = itemTypeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ItemType>?> GetAllItemTypesAsync()
    {
        return await _itemTypeRepository.GetAllItemTypesAsync();
    }

    public async Task PostItemTypeAsync(ItemTypeRequestDTO itemType)
    {
        var item = _mapper.Map<ItemType>(itemType);
        await _itemTypeRepository.Post(item);
    }
}
