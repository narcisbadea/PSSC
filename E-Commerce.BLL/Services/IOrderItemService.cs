using E_Commerce.BLL.DTOs;
using E_Commerce.Domain.DTOs;

namespace E_Commerce.BLL.Services
{
    public interface IOrderItemService
    {
        Task AddItemInOrder(ItemInOrderDTO itemInOrder);
    }
}