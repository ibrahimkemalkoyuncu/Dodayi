using Dodayi.Services.AuthAPI.Dto;

namespace Dodayi.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegisterationRequest dto);
        Task<LoginResponse> Login(LoginRequest dto);
    }
}
