using ImmoGest.Application.DTOs.Auth;
using ImmoGest.Domain.Entities;

namespace ImmoGest.Application.Interfaces
{
    public interface IAuthService
    {
        JwtDto GenerateToken(User user);
    }
}
