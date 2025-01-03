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

        public AuthService(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public Task<LoginResponse> Login(LoginRequest dto)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Register(RegisterationRequest dto)
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

                    User userDto = new User
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
