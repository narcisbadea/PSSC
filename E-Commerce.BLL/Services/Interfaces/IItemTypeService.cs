
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.BLL.Services.Interfaces
{
    public interface IItemTypeService
    {
        Task<IEnumerable<ItemType>?> GetAllItemTypesAsync();
        Task PostItemTypeAsync(ItemTypeRequestDTO itemType);
    }
}