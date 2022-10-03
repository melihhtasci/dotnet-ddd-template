using Application.Services.Authentication;
using Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest reqisterRequest)
        {
            var authResult = _authenticationService.Register(
                reqisterRequest.FirstName, 
                reqisterRequest.LastName,
                reqisterRequest.Email, 
                reqisterRequest.Password);
            
            var response = new AuthenticationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var loginResult = _authenticationService.Login(loginRequest.Email, loginRequest.Password);

            var response = new AuthenticationResponse(
                loginResult.Id,
                loginResult.FirstName,
                loginResult.LastName,
                loginResult.Email,
                loginResult.Token);

            return Ok(response);;
        }


    }
}
