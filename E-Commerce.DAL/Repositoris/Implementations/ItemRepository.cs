using E_Commerce.DAL.Database;
using E_Commerce.DAL.Repositoris.Interfaces;
using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL.Repositoris.Implementations;

public class ItemRepository : IItemRepository
{
    private readonly DatabaseContext _context;

    public ItemRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> GetAllItemsAsync()
    {
        return await _context.Items
            .Include(i => i.ItemType)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Item?> GetItemByIdAsync(string Id)
    {
        return await _context.Items
            .Include(i => i.ItemType)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == Id);
    }

    public async Task DeleteItemByIdAsync(string Id)
    {
        var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == Id);
        if (item != null)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> AddItemAsync(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
        var result = await _context.Items.FirstOrDefaultAsync(i => i.Id == item.Id);
        if (result == null)
        {
            return false;
        }
        return true;
    }

    public async Task UpdateItemAsync(Item item)
    {
        _context.Items.Update(item);
        await _context.SaveChangesAsync();
    }
}
