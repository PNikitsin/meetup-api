using Microsoft.AspNetCore.Mvc;
using Meetups.Application.Services;
using Meetups.Application.DTOs;

namespace Meetups.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AccountController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost]
        [Route("login-user")]
        public async Task<IActionResult> LoginAsync(LoginUserDto loginUserDto)
        {
            var secretKey = _configuration.GetValue<string>("Token:Key");
            var durationTime = _configuration.GetValue<double>("Token:DurationInMinutes");

            var token = await _userService.LoginUserAsync(loginUserDto, secretKey, durationTime);

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