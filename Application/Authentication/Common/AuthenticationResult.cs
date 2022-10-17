using Domain;

namespace Application.Authentication.Common;

public record AuthenticationResult(User User, string? Token);
