using Dodayi.Services.AuthAPI.Models;

namespace Dodayi.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
