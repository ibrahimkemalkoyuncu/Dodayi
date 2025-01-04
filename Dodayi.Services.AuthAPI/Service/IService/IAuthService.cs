using Dodayi.Services.AuthAPI.Dto;

namespace Dodayi.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegisterationRequestDto dto);
        Task<LoginResponseDto> Login(LoginRequestDto dto);
    }
}
