using E_Commerce.BLL.DTOs;
using E_Commerce.DAL.Repositoris.Implementations;
using E_Commerce.DAL.Repositoris.Interfaces;
using E_Commerce.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly UserManager<User> _userManager;
    private readonly IItemRepository _itemRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository, IItemRepository itemRepository, UserManager<User> userManager)
    {
        _orderItemRepository = orderItemRepository;
        _itemRepository = itemRepository;
        _userManager = userManager;
    }

    public async Task AddItemInOrder(ItemInOrderDTO itemInOrder)
    {
        var item = await _itemRepository.GetItemByIdAsync(itemInOrder.ItemId);
        var user = await _userManager.FindByIdAsync(itemInOrder.UserId);
        await _orderItemRepository.AddItemInOrder(item, user, itemInOrder.Quantity);
    }
}
