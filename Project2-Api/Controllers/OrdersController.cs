using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2_Api.Data.Entities;
using Project2_Api.Services;

namespace Project2_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _ordertService;
        public OrdersController(OrderService ordertService)
        {
            _ordertService = ordertService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _ordertService.GetAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            var result = await _ordertService.GetsAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Order order)
        {
            await _ordertService.AddAsync(order);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Order order)
        {
            await _ordertService.EditAsync(order);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _ordertService.DeleteAsync(id);
            return Ok();
        }
    }
}
