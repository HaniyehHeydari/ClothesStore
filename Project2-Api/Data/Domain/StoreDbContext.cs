using Project2_Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Project2_Api.Data.Domain;

public class StoreDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<Order> Orders { get; set; }
    public StoreDbContext(DbContextOptions<StoreDbContext> options) 
        : base(options)
    {

    }
}
