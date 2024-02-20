using Carter;
using DistributedSystem.Contract.Services.V1.Identity;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Presentation.Abstractions;

namespace Presentation.APIs.Identity;

public class TokenApi : ApiEndpoint, ICarterModule
{
    private const string BaseUrl = "/api/v{version:apiVersion}/token";
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group1 = app.NewVersionedApi("Token")
            .MapGroup(BaseUrl).HasApiVersion(1).RequireAuthorization();

        group1.MapPost("refresh", RefreshV1);
        // group1.MapPost("revoke", RevokeV1);
    }

    public static async Task<IResult> RefreshV1(ISender sender, HttpContext httpContext, [FromBody] Command.Token token)
    {
        var accessToken = await httpContext.GetTokenAsync("access_token");
        var result = await sender.Send(new Command.Token(accessToken, token.RefreshToken));

        if (result.IsFailure)
            return HandlerFailure(result);

        return Results.Ok(result);
    }

    // public static async Task<IResult> RevokeV1(ISender sender, HttpContext httpContext)
    // {
    //     var AccessToken = await httpContext.GetTokenAsync("access_token");
    //
    //     var result = await sender.Send(new DistributedSystem.Contract.Services.V1.Identity.Command.Revoke(AccessToken));
    //
    //     return Results.Ok(result);
    // }
}