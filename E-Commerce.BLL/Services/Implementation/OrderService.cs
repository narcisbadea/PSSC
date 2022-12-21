using AutoMapper;
using E_Commerce.BLL.Services.Interfaces;
using E_Commerce.DAL.Repositoris.Interfaces;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.BLL.Services.Implementation;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<string> CancelOrder(string OrderId, User user)
    {
        var order = await _orderRepository.GetOrderByIdAsync(OrderId);
        if (order is not null)
        {
            return await _orderRepository.CancelOrder(order, user);
        }
        return "Error: Order not found!";
    }
    public async Task<string> TakeOrder(string OrderId)
    {
        var order = await _orderRepository.GetOrderByIdAsync(OrderId);
        if (order is not null)
        {
            return await _orderRepository.TakeOrder(order);
        }
        return "Error: Order not found!";
    }

    public async Task<OrderDTO> GetOrderByIdToAdmin(string id)
    {
        return await _orderRepository.GetOrderByIdToAdmin(id);
    }

    public async Task<IEnumerable<OrderViewDTO>> GetAllOrders()
    {
       var result = await _orderRepository.GetAllOrdersAsync();
        return _mapper.Map<IEnumerable<Order>,IEnumerable<OrderViewDTO>>(result);
    }

}
