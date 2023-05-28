using Meetups.Web.Application.DTOs;

namespace Meetups.Web.Application.Services
{
    public interface IUserService
    {
        public Task RegisterUserAsync(RegisterUserDto registerUserDto);
        public Task<string> LoginUserAsync(LoginUserDto loginUserDto, string secretKey, double durationTime);
    }
}