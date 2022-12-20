using E_Commerce.DAL.Database;
using E_Commerce.DAL.Repositoris.Interfaces;
using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL.Repositoris.Implementations;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly DatabaseContext _context;

    public OrderItemRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AddItemInOrder(Item item, User user, int quantity)
    {
        var orderInProgress = await _context.Orders
            .Where(o => o.User.Id == user.Id)
            .Where(o => o.Status == Status.InProgress)
            .FirstOrDefaultAsync();
        var itm = _context.Items.Attach(item).Entity;
        itm.Quantity -= quantity;
        if (itm.Quantity >= 0)
        {
            if (orderInProgress is null)
            {
                var order = new Order
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.UtcNow,
                    Status = Status.InProgress,
                    User = user
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }
            orderInProgress = await _context.Orders
                .Where(o => o.User.Id == user.Id)
                .Where(o => o.Status == Status.InProgress)
                .FirstOrDefaultAsync();
            _context.OrderItem.Add(new OrderItem
            {
                Id = Guid.NewGuid().ToString(),
                Order = orderInProgress,
                Item = item,
                Quantity = quantity
            });
            await _context.SaveChangesAsync();
        }
    }
}
