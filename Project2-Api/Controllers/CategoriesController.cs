using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2_Api.Data.Entities;
using Project2_Api.Services;

namespace Project2_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoriesController(CategoryService categoryService)
        {
            _categoryService=categoryService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.GetAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            var result = await _categoryService.GetsAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            await _categoryService.AddAsync(category);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Category category)
        {
            await _categoryService.EditAsync(category);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
