﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2_Api.Data.Entities;
using Project2_Api.Services;
using Shared.Models.Category;

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
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.GetAsync(id);
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            var result = await _categoryService.GetsAsync();
            return Ok(result);
        }
        /// <summary>
        /// اضافه کردن یک دسته بندی
        /// </summary>
        /// <param name="category">اطلاعات دسته بندی</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddRequestDto category)
        {
            await _categoryService.AddAsync(category);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Category category)
        {
            await _categoryService.EditAsync(category);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
