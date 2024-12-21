using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;

namespace WebApplication1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : BaseController
    {
        private readonly IUserService _userService = userService;
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return HandleResult(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            var User = await _userService.GetUserByIdAsync(id);
            return HandleResult(User);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] UserDTO UserDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userService.AddUserAsync(UserDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(string id, [FromBody] UserDTO UserDto)
        {
            if ( id != UserDto.Id) return BadRequest(ModelState);
            await _userService.UpdateUserAsync(UserDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
