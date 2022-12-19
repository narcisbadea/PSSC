using E_Commerce.DAL.Repositoris.Interfaces;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IAuthService _authService;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<string> CancelOrder(string OrderId, User user)
    {
        var order = await _orderRepository.GetOrderByIdAsync(OrderId);
        return await _orderRepository.CancelOrder(order, user);
    }
    public async Task<string> TakeOrder(string OrderId)
    {
        var order = await _orderRepository.GetOrderByIdAsync(OrderId);
        return await _orderRepository.TakeOrder(order);
    }

    public async Task<OrderDTO> GetOrderByIdToAdmin(string id)
    {
        var order = await _orderRepository.GetOrderByIdToAdmin(id);
        return order;
    }

}
