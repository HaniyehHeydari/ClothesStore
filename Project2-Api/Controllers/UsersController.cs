using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2_Api.Data.Entities;
using Project2_Api.Services;

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
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            var result = await _userService.GetsAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(User user)
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
