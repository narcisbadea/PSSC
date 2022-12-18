using E_Commerce.DAL.Database;
using E_Commerce.DAL.Repositoris.Interfaces;
using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Repositoris.Implementations;

public class ItemTypeRepository : IItemTypeRepository
{
    private readonly DatabaseContext _context;

    public ItemTypeRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ItemType?> GetTypeByIdAsync(string id)
    {
        return await _context.Types.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<ItemType>> GetAllItemTypesAsync()
    {
        return await _context.Types.ToListAsync();
    }

    public async Task Post(ItemType itemType)
    {
        _context.Add(itemType);
        await _context.SaveChangesAsync();
    }
}
