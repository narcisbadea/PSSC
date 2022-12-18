using E_Commerce.Domain.Models;

namespace E_Commerce.DAL.Repositoris.Interfaces
{
    public interface IItemTypeRepository
    {
        Task<IEnumerable<ItemType>> GetAllItemTypesAsync();
        Task<ItemType?> GetTypeByIdAsync(string id);
        Task Post(ItemType itemType);
    }
}