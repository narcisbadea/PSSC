using E_Commerce.DAL.Database;
using E_Commerce.DAL.Repositoris.Interfaces;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL.Repositoris.Implementations;

public class OrderRepository : IOrderRepository
{
    private readonly DatabaseContext _context;

    public OrderRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders
            .Include(u => u.User)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(string Id)
    {
        return await _context.Orders.FirstOrDefaultAsync(i => i.Id == Id);
    }

    public async Task DeleteOrderByIdAsync(string Id)
    {
        var item = await _context.Orders.FirstOrDefaultAsync(i => i.Id == Id);
        if (item != null)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> AddOrderAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        var result = await _context.Orders.FirstOrDefaultAsync(i => i.Id == order.Id);
        if (result == null)
        {
            return false;
        }
        return true;
    }

    public async Task UpdateOrderAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task<string> CancelOrder(Order order, User user)
    {
        var orderToCancel = await _context.Orders
            .Include(o => o.User)
            .FirstOrDefaultAsync(o => o.Id == order.Id);
        _context.Users.Attach(user);
        if (orderToCancel is not null)
        {
            if (orderToCancel.User.Id == user.Id)
            {
                if (orderToCancel.Status != Status.Shipped)
                {
                    orderToCancel.Status = Status.CanceledByTheCustomer;
                    await _context.SaveChangesAsync();
                    return "Order canceled!";
                }
                else
                {
                    return "Error: Order shipped!";
                }
            }
            else
            {
                return "Error: It's not your order!";
            }
        }
        return "Error: Order not fout!";
    }

    public async Task<OrderDTO> GetOrderByIdToAdmin(string id)
    {
        var result = await _context.OrderItem
            .Include(o => o.Order)
                .ThenInclude(o => o.User)
            .Include(o => o.Item)
            .Where(o => o.Order.Id == id)
            .ToListAsync();
        if (result.Count > 0)
        {
            var items = new List<ItemInOrderDTOToAdmin>();
            foreach (var item in result)
            {
                items.Add(new ItemInOrderDTOToAdmin
                {
                    ItemName = item.Item.Name,
                    Quantity = item.Quantity
                });
            }
            var order = new OrderDTO
            {
                FirstName = result[0].Order.User.FirstName,
                LastName = result[0].Order.User.LastName,
                Address = result[0].Order.User.Adress,
                Items = items,
                Status = result[0].Order.Status.ToString()
            };

            return order;
        }
        return new OrderDTO();
    }

    public async Task<string> TakeOrder(Order order)
    {
        var orderToCancel = await _context.Orders
            .Include(o => o.User)
            .FirstOrDefaultAsync(o => o.Id == order.Id);
        if (orderToCancel is null)
        {
            return "Error: Order not found!";
        }
        orderToCancel.Status = Status.Taken;
        await _context.SaveChangesAsync();
        return "Order tacked!";

    }
}

