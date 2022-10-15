using API.Filters;
using Application.Services.Authentication;
using Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest reqisterRequest)
        {
            ErrorOr<AuthenticationResult> authResult =
                _authenticationService.Register(
                reqisterRequest.FirstName,
                reqisterRequest.LastName,
                reqisterRequest.Email,
                reqisterRequest.Password);

            return authResult.Match(
                authResult => Ok(MapAuth(authResult)),
                errors => Problem(errors)
                );

        }

        private static AuthenticationResponse MapAuth(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                            authResult.User.Id,
                            authResult.User.FirstName,
                            authResult.User.LastName,
                            authResult.User.Email,
                            authResult.Token);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var loginResult = _authenticationService.Login(loginRequest.Email, loginRequest.Password);

            return loginResult.Match(
                authResult => Ok(MapAuth(authResult)),
                errors => Problem(errors)
                );

        }


    }
}
