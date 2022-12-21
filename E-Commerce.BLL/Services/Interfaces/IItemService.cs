
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.BLL.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemResponseDTO>> GetAllItemsAsync();
        Task InsertItemAsync(ItemRequestDTO item);
    }
}