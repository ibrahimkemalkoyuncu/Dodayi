using Dodayi.Services.AuthAPI.Dto;

namespace Dodayi.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto dto);
        Task<LoginResponseDto> Login(LoginRequestDto dto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
