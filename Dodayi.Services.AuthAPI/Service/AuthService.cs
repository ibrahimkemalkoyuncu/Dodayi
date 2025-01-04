using Dodayi.Services.AuthAPI.Data;
using Dodayi.Services.AuthAPI.Dto;
using Dodayi.Services.AuthAPI.Models;
using Dodayi.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace Dodayi.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext db, IJwtTokenGenerator jwtTokenGenerator,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<LoginResponseDto> Login(LoginRequestDto dto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == dto.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDto() { User = null, Token = "" };
            }

            // if user was found, Generated JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);    


            UserDto userDto = new()
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDto loginResponse = new()
            {
                User = userDto,
                Token = token
            };

            return loginResponse;
        }
        public async Task<string> Register(RegisterationRequestDto dto)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                NormalizedEmail = dto.Email.ToUpper(),
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber           
            };

            try
            {
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == dto.Email);

                    UserDto userDto = new()
                    {
                        Email = userToReturn.Email,
                        ID = userToReturn.Id,   
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };

                    return ""; 
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {

            }

            return "Error Encountered";
        }
    }
}
