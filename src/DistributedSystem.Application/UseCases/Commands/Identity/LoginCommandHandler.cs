using System.Security.Claims;
using DistributedSystem.Application.Abstractions;
using DistributedSystem.Contract.Abstractions.Messages;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Identity;

namespace DistributedSystem.Application.UseCases.Commands.Identity;

public class LoginCommandHandler : ICommandHandler<Command.Login>
{
    private readonly IJwtTokenService _jwtTokenService;
    private readonly ICacheService _cacheService;

    public LoginCommandHandler(IJwtTokenService jwtTokenService, ICacheService cacheService)
    {
        _jwtTokenService = jwtTokenService;
        _cacheService = cacheService;
    }

    public async Task<Result> Handle(Command.Login request, CancellationToken cancellationToken)
    {
        // Check User

        // Generate JWT Token
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, request.Email),
            new(ClaimTypes.Role, "Senior .NET Leader")
        };

        var accessToken = _jwtTokenService.GenerateAccessToken(claims);
        var refreshToken = _jwtTokenService.GenerateRefreshToken();

        var response = new Response.Authenticated(accessToken, refreshToken, DateTime.Now.AddMinutes(5))
            ;

        await _cacheService.SetAsync(request.Email, response, cancellationToken);

        return Result.Success(response);
    }
}