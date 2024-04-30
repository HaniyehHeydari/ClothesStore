﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2_Api.Data.Entities;
using Project2_Api.Services;
using Shared.Models.Basket;

namespace Project2_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly BasketService _basketService;
        public BasketsController(BasketService basketService)
        {
            _basketService = basketService;
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
        /// <summary>
        /// اضافه کردن یک محصول به سبد خرید
        /// </summary>
        /// <param name="basket">اطلاعات محصول</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(BasketAddRequestDto basket)
        {
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
    }
}
