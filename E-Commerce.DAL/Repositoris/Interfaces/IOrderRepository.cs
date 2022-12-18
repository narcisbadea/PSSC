using E_Commerce.Domain.Models;

namespace E_Commerce.DAL.Repositoris.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> AddOrderAsync(Order order);
        Task DeleteOrderByIdAsync(string Id);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(string Id);
        Task UpdateOrderAsync(Order order);
    }
}