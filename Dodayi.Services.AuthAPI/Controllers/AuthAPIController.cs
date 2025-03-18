using Dodayi.Services.AuthAPI.Dto;
using Dodayi.Services.AuthAPI.Service.IService;
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
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
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
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }


        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered ";
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}
