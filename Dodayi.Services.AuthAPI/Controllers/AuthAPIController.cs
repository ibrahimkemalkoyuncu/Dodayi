using Dodayi.Services.AuthAPI.Dto;
using Dodayi.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dodayi.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected Response _response;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _response = new Response();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequest model)
        {
            var errorMessages = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessages))
            {
                _response.IsSuccess = false;
                _response.Message =  errorMessages;
                return BadRequest(_response);
            }

            return Ok(_response);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
