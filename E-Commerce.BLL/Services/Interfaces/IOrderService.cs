using E_Commerce.BLL.DTOs;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        Task<string> CancelOrder(string OrderId, User user);
        Task<IEnumerable<OrderViewDTO>> GetAllOrders();
        Task<OrderDTO> GetOrderByIdToAdmin(string id);
        Task<string> TakeOrder(string OrderId);
    }
}