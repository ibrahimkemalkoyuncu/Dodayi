using Microsoft.AspNetCore.Identity;

namespace Dodayi.Services.AuthAPI.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }

    }
}
