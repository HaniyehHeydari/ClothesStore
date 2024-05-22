using Microsoft.EntityFrameworkCore;
using Project2_Api.Data.Domain;
using Project2_Api.Data.Entities;
using Shared.Models.Order;
using Shared.Models.Orders;
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
        public async Task<List<Order?>> GetsByProductAsync(int productId)
        {
            List<Order> orders = await _context.Orders.Where(order => order.ProductId == productId).ToListAsync();
            return orders;
        }
        public async Task<List<Order?>> GetsByUserAsync(string userId)
        {
            List<Order> orders = await _context.Orders.Where(order => order.UserId == userId).ToListAsync();
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
            IQueryable<Order> orders = _context.Orders
               .Where(a =>
                               (model.Count == null || a.Count <= model.Count)
                               && (model.FromDate == null || a.CreatedAt >= model.FromDate)
                               && (model.ToDate == null || a.CreatedAt <= model.ToDate)
                               && (model.UserFirstName == null || a.User.FirstName.Contains(model.UserFirstName))
                               && (model.UserLastName == null || a.User.LastName.Contains(model.UserLastName))
                               && (model.ProductName == null || a.Product.Name.Contains(model.ProductName))
                               );

            if (!string.IsNullOrEmpty(model.SortBy))
            {
                switch (model.SortBy)
                {
                    case "CountAsc":
                        orders = orders.OrderBy(a => a.Count);
                        break;
                    case "CountDesc":
                        orders = orders.OrderByDescending(a => a.Count);
                        break;
                }
            }

            orders = orders
                            .Skip(model.PageNo * model.PageSize)
                            .Take(model.PageSize);

            var Orders = await orders
                            .Select(a => new SearchResponseOrderDto
                             {
                                  ProductId = a.Id,
                                  ProductName = a.Product.Name,
                                  UserId = a.UserId,
                                  Count = a.Count,
                                  Price = a.price,
                                  CreatedAt = a.CreatedAt,
                                  Description = a.Product.Description,
                                  UserFirstName = a.User.FirstName,
                                  UserLastName = a.User.LastName,
                                  ProductImageFileName = a.Product.ImageFileName
                             })
                            .ToListAsync();

            return Orders;
        }

        public async Task<List<OrderReportByProductPriceResponseDto>> OrdersReportByProductPriceAsync(OrderReportByProductPriceRequestDto model)
        {
            var ordersQuery = _context.Orders.Where(a =>
                                       (model.FromDate == null || a.CreatedAt >= model.FromDate)
                                    && (model.ToDate == null || a.CreatedAt <= model.ToDate)
                                   )
                .GroupBy(a => a.ProductId)
                .Select(a => new
                {
                    ProductId = a.Key,
                    TotalSum = a.Sum(s => s.price),
                });
            var productsQuery = from product in _context.Products
                           from order in ordersQuery.Where(a => a.ProductId == product.Id).DefaultIfEmpty()
                           select new OrderReportByProductPriceResponseDto
                           {
                               ProductId = product.Id,
                               ProductName =product.Name,
                               ProductCategoryName=product.Category.Name,
                               TotalSum=(int?) order.TotalSum

                           };
            productsQuery= productsQuery.Skip(model.PageNo * model.PageSize)
                                .Take(model.PageSize);
            var result = await productsQuery.ToListAsync();
            return result;

        }
        public async Task<List<OrderReportByProductPriceResponseDto>> OrdersReportByProductCountAsync(OrderReportByProductCountRequestDto model)
        {
            var ordersQuery = _context.Orders.Where(a =>
                                       (model.FromDate == null || a.CreatedAt >= model.FromDate)
                                    && (model.ToDate == null || a.CreatedAt <= model.ToDate)
                                   )
                .GroupBy(a => a.ProductId)
                .Select(a => new
                {
                    ProductId = a.Key,
                    TotalSum = a.Sum(s => s.Count),
                });
            var productsQuery = from product in _context.Products
                                from order in ordersQuery.Where(a => a.ProductId == product.Id).DefaultIfEmpty()
                                select new OrderReportByProductPriceResponseDto
                                {
                                    ProductId = product.Id,
                                    ProductName = product.Name,
                                    ProductCategoryName = product.Category.Name,
                                    TotalSum = (int?)order.TotalSum

                                };
            productsQuery = productsQuery.Skip(model.PageNo * model.PageSize)
                                .Take(model.PageSize);
            var result = await productsQuery.ToListAsync();
            return result;
        }

        public async Task<List<OrderReportByProductNameResponseDto>> OrderReportByProductNameAsync(OrderReportByProductNameRequestDto model)
        {
            var filteredProducts = _context.Products
                                            .Where(p => model.ProductName == null || p.Name.Contains(model.ProductName));

            var ordersWithFilteredProducts = await _context.Orders
                                                             .Join(filteredProducts,
                                                                   order => order.ProductId,
                                                                   product => product.Id,
                                                                   (order, product) => new { Order = order, Product = product })
                                                                 .GroupBy(x => x.Order.ProductId)
                                                                 .Select(g => new
                                                                 {
                                                                     ProductId = g.Key,
                                                                     OrderSum = g.Sum(x => x.Order.price * x.Order.Count),
                                                                     ProductName = g.FirstOrDefault().Product.Name
                                                                 })
                                                                 .ToListAsync();

            var result = ordersWithFilteredProducts.Select(o => new OrderReportByProductNameResponseDto
            {
                ProductName = o.ProductName,
                ProductId = o.ProductId,
                OrderSum = o.OrderSum
            }).ToList();

            result = result.Skip((model.PageNo) * model.PageSize).Take(model.PageSize).ToList();

            return result;
        }
    }
}  
