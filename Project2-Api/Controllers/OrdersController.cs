using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2_Api.Data.Domain;
using Project2_Api.Data.Entities;
using Project2_Api.Services;
using Shared.Models.Order;
using Shared.Models.Orders;
using Shared.Models.Products;

namespace IbulakStoreServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly StoreDbContext _context;


        public OrderController(OrderService orderService, StoreDbContext context)
        {
            _orderService = orderService;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _orderService.GetAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            var result = await _orderService.GetsAsync();
            return Ok(result);
        }
        [HttpGet("GetsByProduct")]
        public async Task<IActionResult> GetsByProduct(int productId)
        {
            var result = await _orderService.GetsByProductAsync(productId);
            return Ok(result);
        }
        [HttpGet("GetsByUser")]
        public async Task<IActionResult> GetsByUser(string userId)
        {
            var result = await _orderService.GetsByUserAsync(userId);
            return Ok(result);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] SearchRequestOrderDto model)
        {
            var result = await _orderService.SearchAsync(model);
            return Ok(result);
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> AddRange(List<OrderAddRequestDto> orders)
        {
            var orderEntities = new List<Order>();
            foreach (var orderDto in orders)
            {
                Product? product = await _context.Products.FindAsync(orderDto.ProductId);
                if (product is null)
                {
                    return NotFound($"محصولی با شناسه {orderDto.ProductId} پیدا نشد.");
                }

                if (orderDto.Count > product.Count)
                {
                    return BadRequest($"تعداد محصول درخواستی بیشتر از موجودی است. تعداد موجود: {product.Count}");
                }
                product.Count -= orderDto.Count;
                _context.Products.Update(product);

                var order = new Order
                {
                    Count = orderDto.Count,
                    price = orderDto.price,
                    ProductId = orderDto.ProductId,
                    UserId = orderDto.UserId,
                    CreatedAt = DateTime.Now
                };

                orderEntities.Add(order);
            }

            _context.Orders.AddRange(orderEntities);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Order order)
        {
            await _orderService.EditAsync(order);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteAsync(id);
            return Ok();
        }
        [HttpGet("OrdersReportByProductPrice")]
        public async Task<IActionResult> OrdersReportByProductPrice([FromQuery]OrderReportByProductPriceRequestDto model)
        {
           var result = await _orderService.OrdersReportByProductPriceAsync(model);
            return Ok(result);
        }
        [HttpGet("OrderReportByProductCount")]
        public async Task<IActionResult> OrderReportByProductCount([FromQuery] OrderReportByProductCountRequestDto model)
        {
            var result = await _orderService.OrdersReportByProductCountAsync(model);
            return Ok(result);
        }
        [HttpGet("OrderReportByProductName")]
        public async Task<IActionResult> OrderReportByProductName([FromQuery] OrderReportByProductNameRequestDto model)
        {
            var result = await _orderService.OrderReportByProductNameAsync(model);
            return Ok(result);
        }
        [HttpGet("OrderTotal")]
        public async Task<IActionResult> OrderTotalAsync([FromQuery] OrderTotalRequestDto model)
        {
            var result = await _orderService.OrderTotalAsync(model);
            return Ok(result);
        }
        [HttpGet("OrdersReportByDate")]
        public async Task<IActionResult> OrdersReportByDate([FromQuery] OrderReportByDateRequestDto model)
        {
            var resualt = await _orderService.OrdersReportByDateAsync(model);
            return Ok(resualt);
        }
    }
}
