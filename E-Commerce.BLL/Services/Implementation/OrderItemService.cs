using E_Commerce.Domain.DTOs;
using E_Commerce.BLL.Services.Interfaces;
using E_Commerce.DAL.Repositoris.Interfaces;
using E_Commerce.Domain.Models;

namespace E_Commerce.BLL.Services.Implementation;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IItemRepository _itemRepository;
    public OrderItemService(IOrderItemRepository orderItemRepository, IItemRepository itemRepository)
    {
        _orderItemRepository = orderItemRepository;
        _itemRepository = itemRepository;
    }

    public async Task AddItemInOrder(ItemInOrderDTO itemInOrder, User user)
    {
        var item = await _itemRepository.GetItemByIdAsync(itemInOrder.ItemId);
        if (item is not null)
        {
            await _orderItemRepository.AddItemInOrder(item, user, itemInOrder.Quantity);
        }
    }
}
