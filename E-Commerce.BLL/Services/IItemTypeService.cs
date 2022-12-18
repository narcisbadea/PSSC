using E_Commerce.BLL.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.BLL.Services
{
    public interface IItemTypeService
    {
        Task<IEnumerable<ItemType>> GetAllItemTypesAsync();
        Task PostItemTypeAsync(ItemTypeRequestDTO itemType);
    }
}