using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Project2_Api.Controllers;
using Project2_Api.Data.Domain;
using Project2_Api.Data.Entities;
using Shared.Models.Product;
using Shared.Models.Products;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Project2_Api.Services
{
    public class ProductService
    {
        private readonly StoreDbContext _context;
        public ProductService(StoreDbContext context)
        {
            _context = context;
        }
        public Product? Get(int id) 
        { 
            Product product = _context.Products.Find(id);
            return product;
        }
        public async Task<Product?> GetAsync(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            return product;
        }
        public async Task<Product?> FindByIdAsync(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            return product;
        }
        public async Task<List<Product?>> GetsAsync()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products;
        }
        public async Task<List<Product?>> GetsByCategoryAsync(int categoryId)
        {
            List<Product> products = await _context.Products.Where(product=> product.CategoryId== categoryId).ToListAsync();
            return products;
        }
        public async Task AddAsync(ProductAddRequestDto model)
        {
            Product product = new Product
            {
              CategoryId = model.CategoryId,
              Name = model.Name,
              Description = model.Description,
              Count = model.Count,
              Price = model.Price,
              CreatedAt = model.CreatedAt,
              ImageFileName = model.ImageFileName,
            };
            Category? category = await _context.Categories.FindAsync(product.CategoryId);
            if (category is null)
            {
                throw new Exception("دسته بندی محصولی با این شناسه پیدا نشد.");
            }
            product.Category = category;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task EditAsync(Product product)
        {
            Product? oldProduct = await _context.Products.FindAsync(product.Id);
            if (oldProduct is null) 
            {
                throw new Exception("محصولی با این شناسه پیدا نشد.");
            }
            oldProduct.CategoryId = product.CategoryId;
            oldProduct.Name = product.Name;
            oldProduct.Description = product.Description;
            oldProduct.Count = product.Count;
            oldProduct.Price = product.Price;
            oldProduct.ImageFileName = product.ImageFileName;
            _context.Products.Update(oldProduct);
            await _context.SaveChangesAsync();
        } public async Task DeleteAsync(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            if (product is null)
            {
                throw new Exception("محصولی با این شناسه پیدا نشد.");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SearchResponseProductDto>> SearchAsync(SearchRequestProductDto model)
        {
            IQueryable<Product> products = _context.Products
                                    .Where(a =>
                                    (model.Count == null || a.Count <= model.Count)
                                    && (model.FromDate == null || a.CreatedAt >= model.FromDate)
                                    && (model.ToDate == null || a.CreatedAt <= model.ToDate)
                                    && (model.CategoryName == null || a.Category.Name.Contains(model.CategoryName))
                                    && (model.ProductName == null || a.Name.Contains(model.ProductName))
                                    && (model.MinPrice == null || a.Price >= model.MinPrice)
                                    && (model.MaxPrice == null || a.Price <= model.MaxPrice));
            if (!string.IsNullOrEmpty(model.SortBy))
            {
                switch (model.SortBy)
                {
                    case "PriceAsc":
                        products = products.OrderBy(a => a.Price);
                        break;
                    case "PriceDesc":
                        products = products.OrderByDescending(a => a.Price);
                        break;
                }
            }


            products = products
                                .Skip(model.PageNo * model.PageSize)
                                .Take(model.PageSize);
            var Products = await products
                                .Select(a => new SearchResponseProductDto
                                {
                                        ProductId = a.Id,
                                        ProductName = a.Name,
                                        CategoryId = a.CategoryId,
                                        Count = a.Count,
                                        Price = a.Price,
                                        CreatedAt = a.CreatedAt,
                                        Description = a.Description,
                                        CategoryName = a.Category.Name,
                                        CategoryImageFileName = a.Category.ImageFileName,
                                        ProductImageFileName = a.ImageFileName,
                                })
                                 .ToListAsync();
            return Products;
        }
    }
}
