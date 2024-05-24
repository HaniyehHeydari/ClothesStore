using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2_Api.Data.Domain;
using Project2_Api.Data.Entities;
using Project2_Api.Services;
using Shared.Models.Product;
using Shared.Models.Products;

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
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.GetAsync(id);
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            var result = await _productService.GetsAsync();
            return Ok(result);
        }
        [Authorize]
        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery]SearchRequestProductDto model)
        {
            var result = await _productService.SearchAsync(model);
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
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
        /// 
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddRequestDto product)
        {
          await _productService.AddAsync(product);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]Product product)
        {
            await _productService.EditAsync(product);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return Ok();
        }
        [Authorize]
        [HttpGet("GetsUnAvailableProducts")]
        public async Task<IActionResult> GetsUnAvailableProductsAsync()
        {
            var result = await _productService.GetsUnAvailableProductsAsync();
            return Ok(result);
        }
    }
}
