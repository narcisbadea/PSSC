using E_Commerce.DAL.Database;
using E_Commerce.DAL.Repositoris.Interfaces;
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
        return await _context.Orders.ToListAsync();
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
}

