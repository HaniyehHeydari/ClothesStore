using Project2_Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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
        protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        const string ADMIN_ROLE_ID = "a2a2df88-2952-408d-9c34-eca9177d92ac";
        const string ADMIN_ID = "2426167f-842e-4933-ae72-d8dfe34abf78";
        builder.Entity<IdentityRole>().HasData(
                                        new IdentityRole { Id = ADMIN_ROLE_ID, Name = "Admin", NormalizedName = "Admin".ToUpper() },
                                          new IdentityRole { Name = "User", NormalizedName = "User".ToUpper() });
        var hasher = new PasswordHasher<IdentityUser>();
        builder.Entity<AppUser>().HasData(
            new AppUser
            {
               Id = ADMIN_ID,
               UserName = "09215682923",
               NormalizedUserName = "09215682923",
               Email = "heyadrihaniyeh51@gmail.com",
               NormalizedEmail = "heyadrihaniyeh51@gmail.com",
               EmailConfirmed = true,
               PhoneNumberConfirmed = true,
               PasswordHash = hasher.HashPassword(null, "Admin1234#"),
               SecurityStamp = string.Empty,
               FirstName= "حانیه",
               LastName="حیدری"
            });
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });
         }
}
