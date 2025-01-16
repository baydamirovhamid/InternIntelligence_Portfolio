using Microsoft.AspNetCore.Mvc;
using Portfolio.BusinessLayer.DTOs;
using Portfolio.BusinessLayer.Services.Interfaces.User;

namespace PortfolioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            var response = await _userService.CreateUserAsync(userDto);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var response = await _userService.GetAllUsersAsync();
            return Ok(response);
        }
    }
}

