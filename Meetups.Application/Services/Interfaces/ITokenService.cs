using System.Security.Claims;

namespace Meetups.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(IEnumerable<Claim> claims, string secretKey);
    }
}