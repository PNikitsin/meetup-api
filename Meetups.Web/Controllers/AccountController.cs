using Microsoft.AspNetCore.Mvc;
using Meetups.Web.Application.DTOs;
using Meetups.Web.Application.Services;

namespace Meetups.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login-user")]
        public async Task<IActionResult> LoginAsync(LoginUserDto loginUserDto )
        {
            var token = await _userService.LoginUserAsync(loginUserDto);

            var response = new
            {
                access_token = token,
                user_name = loginUserDto.UserName
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("register-user")]
        public async Task<IActionResult> RegisterAsync(RegisterUserDto registerModel)
        {
            await _userService.RegisterUserAsync(registerModel);
            return Ok(registerModel);
        }
    }
}