using PrecisionFarming.Application.Common.DTO;
using PrecisionFarming.Domain.Entities.Identity;
using System.Security.Claims;

namespace PrecisionFarming.Application.Common.Interfaces
{
    public interface IJwtService
    {
        AuthResponse CreateJwtToken(AppUser user);
        ClaimsPrincipal? GetPrincipalFromJwtToken(string? token);
    }
}
