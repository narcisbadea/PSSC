using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.DAL.Repositoris.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> AddOrderAsync(Order order);
        Task<string> CancelOrder(Order order, User user);
        Task DeleteOrderByIdAsync(string Id);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(string Id);
        Task<OrderDTO> GetOrderByIdToAdmin(string id);
        Task<string> TakeOrder(Order order);
        Task UpdateOrderAsync(Order order);
    }
}