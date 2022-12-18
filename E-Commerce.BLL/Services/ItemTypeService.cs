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

public class ItemTypeService : IItemTypeService
{
    private readonly IItemTypeRepository _itemTypeRepository;
    private readonly IMapper _mapper;

    public ItemTypeService(IItemTypeRepository itemTypeRepository, IMapper mapper)
    {
        _itemTypeRepository = itemTypeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ItemType>> GetAllItemTypesAsync()
    {
        return await _itemTypeRepository.GetAllItemTypesAsync();
    }

    public async Task PostItemTypeAsync(ItemTypeRequestDTO itemType)
    {
        var item = _mapper.Map<ItemType>(itemType);
        await _itemTypeRepository.Post(item);
    }
}
