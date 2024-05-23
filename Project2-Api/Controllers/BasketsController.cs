using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2_Api.Data.Entities;
using Project2_Api.Services;
using Shared.Models.Basket;
using Shared.Models.Baskets;

namespace Project2_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly BasketService _basketService;
        private readonly ProductService _productService;
        public BasketsController(BasketService basketService, ProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _basketService.GetAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            var result = await _basketService.GetsAsync();
            return Ok(result);
        }
        [HttpGet("GetsByProduct")]
        public async Task<IActionResult> GetsByProduct(int productId)
        {
            var result = await _basketService.GetsByProductAsync(productId);
            return Ok(result);
        }
        [HttpGet("GetsByUser")]
        public async Task<IActionResult> GetsByUser(string userId)
        {
            var result = await _basketService.GetsByUserAsync(userId);
            return Ok(result);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery]SearchRequestBasketDto model)
        {
            var result = await _basketService.SearchAsync(model);
            return Ok(result);
        }
        /// <summary>
        /// اضافه کردن یک محصول به سبد خرید
        /// </summary>
        /// <param name="basket">اطلاعات محصول</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(BasketAddRequestDto basket)
        {
            var product = await _productService.FindByIdAsync(basket.ProductId);
            if (product==null)
            {
                return NotFound(); 
            }
            if (product.Count<basket.Count)
            {
                return BadRequest("این تعداد کالا موجود نمی باشد"); 
            }
            await _basketService.AddAsync(basket);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Basket basket)
        {
            await _basketService.EditAsync(basket);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _basketService.DeleteAsync(id);
            return Ok();
        }
        [HttpGet("BasketReportByUser")]
        public async Task<IActionResult> BasketReportByUser([FromQuery] BasketReportByUserRequestDto model)
        {
            var result = await _basketService.BasketReportByUserAsync(model);
            return Ok(result);
        }
        [HttpGet("BasketReportByUserProductCountAsync")]
        public async Task<IActionResult> BasketReportByUserProductCountAsync([FromQuery] BasketReportByUserProductCountRequestDto model)
        {
            var result = await _basketService.BasketReportByUserProductCountAsync(model);
            return Ok(result);
        }
    }
}
