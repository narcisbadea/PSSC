using E_Commerce.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace E_Commerce.DAL.Database;

public class DatabaseContext : IdentityDbContext<User, Role, string>
{
    private readonly IConfiguration _configuration;
    public DatabaseContext(IConfiguration configuration) : base()
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("E-CommerceDatabase"));
    }


    public DbSet<ItemType> Types { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        this.SeedRoles(modelBuilder);

        modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(l => new { l.LoginProvider, l.ProviderKey });

        modelBuilder.Entity<Order>()
                    .Property(e => e.Status)
                    .HasConversion<string>();
    }

    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<Role>().HasData(
            new Role() { Id = "9d22ff52-1a0d-4832-997f-27e57e68ec9e", Name = "User", NormalizedName = "USER" },
            new Role() { Id = "b1a678cf-d7a2-415a-9a8f-52d51e067e88", Name = "Admin", NormalizedName = "ADMIN" });
    }
}
