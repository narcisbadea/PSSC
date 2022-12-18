using E_Commerce.DAL.Repositoris.Interfaces;

namespace E_Commerce.BLL.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }


}
