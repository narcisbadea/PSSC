using E_Commerce.DAL.Database;
using E_Commerce.DAL.Repositoris.Interfaces;
using E_Commerce.Domain.Models;

namespace E_Commerce.DAL.Repositoris.Implementations;

public class OderRepository : IOderRepository
{
    private readonly DatabaseContext _context;

    public OderRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task PostOrderAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }
}
