using Microsoft.EntityFrameworkCore;
using Project2_Api.Data.Domain;
using Project2_Api.Data.Entities;
using Shared.Models.Order;
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
            });
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
            oldOrder.BasketId = order.BasketId;
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
    }
}
