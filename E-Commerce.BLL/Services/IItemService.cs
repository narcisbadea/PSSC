using E_Commerce.BLL.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.BLL.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemResponseDTO>> GetAllItemsAsync();
        Task InsertItemAsync(ItemRequestDTO item);
    }
}