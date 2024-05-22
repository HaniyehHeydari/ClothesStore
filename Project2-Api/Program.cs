using Project2_Api.Data.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Project2_Api.Services;
using Project2_Api.Data.Entities;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                              builder => builder
                             .AllowAnyMethod()
                             .AllowAnyHeader()
                             .SetIsOriginAllowed((host) => true)
                             .AllowCredentials()
                             .Build());
        });
        builder.Services.AddAuthorization();

        builder.Services.AddDbContext<StoreDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase")));

        builder.Services
               .AddIdentityApiEndpoints<AppUser>(options=>
               {
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireUppercase = false;
                   options.Password.RequireDigit = false;
                   options.Password.RequiredLength = 6;
               })
               .AddEntityFrameworkStores<StoreDbContext>();

        builder.Services.AddScoped<ProductService>();
        builder.Services.AddScoped<CategoryService>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<BasketService>();
        builder.Services.AddScoped<OrderService>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context1 = services.GetRequiredService<StoreDbContext>();
            context1.Database.Migrate();
        }
        app.UseStaticFiles();
        app.UseCors("CorsPolicy");
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.MapGroup("/account").MapIdentityApi<AppUser>();

        app.Run();
    }
}