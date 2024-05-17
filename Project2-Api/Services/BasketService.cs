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
        public async Task AddAsync(Basket basket)
        {
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

        internal async Task AddAsync(BasketAddRequestDto basket)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SearchResponseBasketDto>> SearchAsync(SearchRequestBasketDto model)
        {
            var baskets = await _context.Baskets
                                   .Where(a =>
                                   (model.Count == null || a.Count <= model.Count)
                                   && (model.UserName == null || a.User.FirstName.Contains(model.ProductName))
                                   && (model.ProductName == null || a.Product.Name.Contains(model.ProductName))
                                   )
                                   .Skip(model.PageNo * model.PageSize)
                                   .Take(model.PageSize)
                                   .Select(a => new SearchResponseBasketDto
                                   {
                                       BasketId = a.Id,
                                       BasketCount = a.Count,
                                       UserId = a.Id,
                                       FirstName = a.User.FirstName,
                                       LastName = a.User.LastName,
                                       ProductId = a.Id,
                                       CategoryId = a.Product.CategoryId,
                                       ProductName = a.Product.Name,
                                       Description = a.Product.Description,
                                       ProductCount = a.Product.Count,
                                       Price = a.Product.Price,
                                       CreatedAt = a.Product.CreatedAt,
                                       ImageFileName = a.Product.ImageFileName,
                                   }
                                   )
                                   .ToListAsync();
            return baskets;
        }
    }
}
