using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2_Api.Data.Domain;
using Project2_Api.Data.Entities;
using Project2_Api.Services;
using Shared.Models.Product;

namespace Project2_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.GetAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            var result = await _productService.GetsAsync();
            return Ok(result);
        }
        [HttpGet("GetByCategory")]
        public async Task<IActionResult> GetsByCategory(int categoryId)
        {
            var result = await _productService.GetsByCategoryAsync(categoryId);
            return Ok(result);
        }
        /// <summary>
        /// اضافه کردن یک محصول
        /// </summary>
        /// <param name="product">اضافه کردن یک محصول</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddRequestDto product)
        {
          await _productService.AddAsync(product);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]Product product)
        {
            await _productService.EditAsync(product);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return Ok();
        }
    }
}
