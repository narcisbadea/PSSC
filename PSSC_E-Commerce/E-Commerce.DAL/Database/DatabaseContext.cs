using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Type = E_Commerce.DAL.Models.Type;

namespace E_Commerce.DAL.Database;

public class DatabaseContext : IdentityDbContext<User, Role, string>
{
    private readonly IConfiguration _configuration;
    public DatabaseContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("E-CommerceDatabase"));
    }


    public DbSet<Type> Types { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
}
