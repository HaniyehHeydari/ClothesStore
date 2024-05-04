using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2_Api.Data.Entities;
using Project2_Api.Services;
using Shared.Models.User;

namespace Project2_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userService.GetAsync(id);
            if (result == null)
            {
                return NotFound("کاربری با این شناسه پیدا نشد.");
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            var result = await _userService.GetsAsync();
            return Ok(result);
        }
        /// <summary>
        /// اضافه کردن یک کاربر
        /// </summary>
        /// <param name="user">اطلاعات کاربر</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(UserAddRequestDto user)
        {
            await _userService.AddAsync(user);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] User user)
        {
            await _userService.EditAsync(user);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
