using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistance;
using Domain;

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

    public AuthenticationResult Login(string Email, string Password)
    {

        if (_userRepository.GetUserByEmail(Email) is not User user)
            throw new Exception("User with given email does not exist.");

        if (user.Password != Password)
            throw new Exception("Invalid password");

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        if (_userRepository.GetUserByEmail(Email) is not null)
            throw new Exception("User with given email already exist.");

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
}