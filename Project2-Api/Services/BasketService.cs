using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Project2_Api.Data.Domain;
using Project2_Api.Data.Entities;
using Shared.Models.Basket;
using Shared.Models.Baskets;
using Shared.Models.Products;
using System.Collections.Generic;

namespace Project2_Api.Services
{
    public class BasketService
    {
        private readonly StoreDbContext _context;
        public BasketService(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<Basket?> GetAsync(int id)
        {
            Basket? basket = await _context.Baskets.FindAsync(id);
            return basket;
        }
        public async Task<List<Basket?>> GetsAsync()
        {
            List<Basket> baskets = await _context.Baskets.ToListAsync();
            return baskets;
        }
        public async Task<List<Basket?>> GetsByProductAsync(int productId)
        {
            List<Basket> baskets = await _context.Baskets.Where(basket => basket.ProductId == productId).ToListAsync();
            return baskets;
        }
        public async Task<List<Basket?>> GetsByUserAsync(string userId)
        {
            List<Basket> baskets = await _context.Baskets.Where(basket => basket.UserId == userId).ToListAsync();
            return baskets;
        }
        public async Task AddAsync(BasketAddRequestDto model)
        {
            Basket basket = new Basket
            {
                UserId = model.UserId,
                Count = model.Count,
                ProductId = model.ProductId,
            };
            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync();
        }
        public async Task EditAsync(Basket basket)
        {
            Basket? oldBasket = await _context.Baskets.FindAsync(basket.Id);
            if (oldBasket is null)
            {
                throw new Exception("سبدی با این شناسه پیدا نشد.");
            }
            oldBasket.UserId = basket.UserId;
            oldBasket.ProductId = basket.ProductId;
            oldBasket.Count = basket.Count;
            _context.Baskets.Update(oldBasket);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Basket? basket = await _context.Baskets.FindAsync(id);
            if (basket is null)
            {
                throw new Exception("سبدی با این شناسه پیدا نشد.");
            }
            _context.Baskets.Remove(basket);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SearchResponseBasketDto>> SearchAsync(SearchRequestBasketDto model)
        {
            IQueryable<Basket> baskets = _context.Baskets
                                   .Where(a =>
                                   (model.Count == null || a.Count <= model.Count)
                                   && (model.UserFirstName == null || a.User.FirstName.Contains(model.UserFirstName))
                                   && (model.UserLastName == null || a.User.LastName.Contains(model.UserLastName))
                                   && (model.ProductName == null || a.Product.Name.Contains(model.ProductName))
                                   );
            if (!string.IsNullOrEmpty(model.SortBy))
            {
                switch (model.SortBy)
                {
                    case "CountAsc":
                        baskets = baskets.OrderBy(a => a.Count);
                        break;
                    case "CountDesc":
                        baskets = baskets.OrderByDescending(a => a.Count);
                        break;
                }
            }
            baskets = baskets
                              .Skip(model.PageNo * model.PageSize)
                              .Take(model.PageSize);

            var Baskets = await baskets
                              .Select(a => new SearchResponseBasketDto
                                   {
                                       BasketId = a.Id,
                                       BasketCount = a.Count,
                                       UserId = a.Id,
                                       UserFirstName = a.User.FirstName,
                                       UserLastName = a.User.LastName,
                                       ProductId = a.Id,
                                       CategoryId = a.Product.CategoryId,
                                       ProductName = a.Product.Name,
                                       Description = a.Product.Description,
                                       ProductCount = a.Product.Count,
                                       Price = a.Product.Price,
                                       CreatedAt = a.Product.CreatedAt,
                                       ImageFileName = a.Product.ImageFileName,
                                   })
                                   .ToListAsync();
            return Baskets;
        }

        public async Task<List<BasketReportByUserResponseDto>> BasketReportByUserAsync(BasketReportByUserRequestDto model)
        {
            var userBaskets = await _context.Baskets
               .Where(b => b.UserId == model.UserId)
               .GroupBy(b => b.ProductId)
               .Select(g => new
               {
                   g.Key,
                   Count = g.Sum(b => b.Count),
                   Product = g.First().Product
               })
               .ToListAsync();

            var report = userBaskets.Select(a => new BasketReportByUserResponseDto
            {
                UserId = model.UserId,
                ProductId = a.Product.Id,
                ProductName = a.Product.Name,
                Count = a.Count,
                TotalSum = a.Product.Price * a.Count
            }).ToList();

            return report;
        }
        public async Task<List<BasketReportByUserProductCountResponceDto>> BasketReportByUserProductCountAsync(BasketReportByUserProductCountRequestDto model)
        {
            var BasketsQuery = await _context.Baskets.Where(a => a.User.Id == model.UserId
                                   )
                .GroupBy(a => a.UserId) 
                .Select(g => new
                {
                    UserId = g.Key,
                    TotalSum = g.Sum(s => s.Count)
                })
            .ToListAsync();
            var result = BasketsQuery.Select(b => new BasketReportByUserProductCountResponceDto
            {

                UserId = model.UserId,
                Count = b.TotalSum
            }).ToList();

            return result;

        }
    }
}
