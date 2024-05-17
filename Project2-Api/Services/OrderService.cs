using Microsoft.EntityFrameworkCore;
using Project2_Api.Data.Domain;
using Project2_Api.Data.Entities;
using Shared.Models.Order;
using Shared.Models.Orders;
using Shared.Models.Products;
using System.Collections.Generic;

namespace Project2_Api.Services
{
    public class OrderService
    {
        private readonly StoreDbContext _context;
        public OrderService(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<Order?> GetAsync(int id)
        {
            Order? order = await _context.Orders.FindAsync(id);
            return order;
        }
        public async Task<List<Order?>> GetsAsync()
        {
            List<Order> orders = await _context.Orders.ToListAsync();
            return orders;
        }


        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
        public async Task AddRengeAsync(List<OrderAddRequestDto> models)
        {
            var orders = models.Select(orderDto=>new Order
            {
                UserId = orderDto.UserId,
                ProductId = orderDto.ProductId,
                Count = orderDto.Count,
                price = orderDto.price,
                CreatedAt = DateTime.Now
            }).ToList();
            _context.Orders.AddRange(orders);
            await _context.SaveChangesAsync();
        }
        public async Task EditAsync(Order order)
        {
            Order? oldOrder = await _context.Orders.FindAsync(order.Id);
            if (oldOrder is null)
            {
                throw new Exception("سفارشی با این شناسه پیدا نشد.");
            }
            oldOrder.UserId = order.UserId;
            oldOrder.ProductId = order.ProductId;
            oldOrder.Count = oldOrder.Count;
            oldOrder.price = oldOrder.price;
            oldOrder.CreatedAt = oldOrder.CreatedAt;
            _context.Orders.Update(oldOrder);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Order? order = await _context.Orders.FindAsync(id);
            if (order is null)
            {
                throw new Exception("سفارشی با این شناسه پیدا نشد.");
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        internal async Task AddAsync(object order)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SearchResponseOrderDto>> SearchAsync(SearchRequestOrderDto model)
        {
            var orders = await _context.Orders
                                    .Where(a =>
                                    (model.Count == null || a.Count <= model.Count)
                                    && (model.FromDate == null || a.CreatedAt >= model.FromDate)
                                    && (model.ToDate == null || a.CreatedAt <= model.ToDate)
                                    && (model.UserFirstName == null || a.User.FirstName.Contains(model.UserFirstName))
                                    && (model.UserLastName == null || a.User.LastName.Contains(model.UserLastName))
                                    && (model.ProductName == null || a.Product.Name.Contains(model.ProductName))
                                    )
                                    .Skip(model.PageNo * model.PageSize)
                                    .Take(model.PageSize)
                                    .Select(a => new SearchResponseOrderDto
                                    {
                                        ProductId = a.Id,
                                        ProductName = a.Product.Name,
                                        UserId = a.UserId,
                                        Count = a.Product.Count,
                                        Price = a.Product.Price,
                                        CreatedAt = a.Product.CreatedAt,
                                        Description = a.Product.Description,
                                        UserFirstName = a.User.FirstName,
                                        UserLastName = a.User.LastName,
                                        ProductImageFileName = a.Product.ImageFileName,
                                    }
                                    )
                                    .ToListAsync();
            return orders;
        }
    }
}
