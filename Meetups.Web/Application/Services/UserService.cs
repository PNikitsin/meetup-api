using Meetups.Domain.Interfaces;
using Meetups.Domain.Entities;
using Meetups.Web.Application.DTOs;
using Meetups.Web.Application.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Meetups.Web.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            var allUsers = await _unitOfWork.Users.GetAllAsync();

            var user = allUsers.FirstOrDefault(u => u.UserName == registerUserDto.UserName);

            if (user == null)
            {
                await _unitOfWork.Users.AddAsync(new User()
                {
                    UserName = registerUserDto.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password)
                });

                await _unitOfWork.CommitAsync();
            }
            else
                throw new AlreadyExistsException("User already exists");
        }

        public async Task<string> LoginUserAsync(LoginUserDto loginUserDto, string secretKey, double durationTime)
        {
            var allUsers = await _unitOfWork.Users.GetAllAsync();

            var user = allUsers.FirstOrDefault(u => u.UserName == loginUserDto.UserName);

            if (user == null)
            {
                throw new NotFoundException("User is not found");
            }

            var passwordHash = BCrypt.Net.BCrypt.Verify(loginUserDto.Password, user.Password);

            if (passwordHash == false)
            {
                throw new Exception("User password is incorrect");
            }

            var token = GenerateToken(user.UserName, secretKey, durationTime);
            return token;
        } 

        private string GenerateToken(string userName, string secretKey, double durationTime)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, userName) };

            var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(durationTime)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(secretKey)), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}