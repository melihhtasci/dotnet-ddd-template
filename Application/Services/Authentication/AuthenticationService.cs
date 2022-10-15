using Application.Common.Errors;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistance;
using Domain;
using Domain.Common.Errors;
using ErrorOr;

namespace Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password)
    {
        if (_userRepository.GetUserByEmail(Email) is not null)
            return Errors.User.DuplicateEmail;

        var user = new User
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Password = Password
        };

        _userRepository.Add(user);

        //var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, null);

    }

    public ErrorOr<AuthenticationResult> Login(string Email, string Password)
    {

        if (_userRepository.GetUserByEmail(Email) is not User user)
            return new[] { Errors.Authentication.InvalidCredentials }; // instead of throw new exception

        if (user.Password != Password)
            return Errors.Authentication.InvalidCredentials;

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
   
}