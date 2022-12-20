using E_Commerce.BLL.DTOs;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.BLL.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task AddItemInOrder(ItemInOrderDTO itemInOrder, User user);
    }
}