using E_Commerce.BLL.DTOs;

namespace E_Commerce.BLL.Services
{
    public interface IOrderItemService
    {
        Task AddItemInOrder(ItemInOrderDTO itemInOrder);
    }
}