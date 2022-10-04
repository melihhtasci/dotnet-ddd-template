using Application.Common.Interfaces.Authentication;

namespace Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "firstname", "lastName", Email, Password);
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        // Check if user already exist

        // Create user (generate unique id)

        // create jwt token
        Guid guid = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(guid, FirstName, LastName);

        return new AuthenticationResult(guid, FirstName, LastName, Email, token);

    }
}