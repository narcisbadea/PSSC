using E_Commerce.Domain.Models;

namespace E_Commerce.DAL.Repositoris.Interfaces
{
    public interface IItemRepository
    {
        Task<bool> AddItemAsync(Item item);
        Task DeleteItemByIdAsync(string Id);
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item?> GetItemByIdAsync(string Id);
        Task UpdateItemAsync(Item item);
    }
}