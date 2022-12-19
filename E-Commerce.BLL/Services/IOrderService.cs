using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.BLL.Services
{
    public interface IOrderService
    {
        Task<string> CancelOrder(string OrderId, User user);
        Task<OrderDTO> GetOrderByIdToAdmin(string id);
        Task<string> TakeOrder(string OrderId);
    }
}