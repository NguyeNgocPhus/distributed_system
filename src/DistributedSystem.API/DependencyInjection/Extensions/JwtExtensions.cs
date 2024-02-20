using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DistributedSystem.API.Attributes;
using DistributedSystem.API.DependencyInjection.Options;
using DistributedSystem.Application.Abstractions;
using DistributedSystem.Contract.Services.V1.Identity;
using DistributedSystem.Infrastructure.DependencyInjection.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace DistributedSystem.API.DependencyInjection.Extensions;

public static class JwtExtensions
{
    public static void AddJwtAuthentication(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            JwtOption jwtOption = new JwtOption();
            configuration.GetSection(nameof(JwtOption)).Bind(jwtOption);

            /**
             * Storing the JWT in the AuthenticationProperties allows you to retrieve it from elsewhere within your application.
             * public async Task<IActionResult> SomeAction()
                {
                    // using Microsoft.AspNetCore.Authentication;
                    var accessToken = await HttpContext.GetTokenAsync("access_token");
                    // ...
                }
             */
            o.SaveToken = true; // Save token into AuthenticationProperties

            var Key = Encoding.UTF8.GetBytes(jwtOption.SecretKey);
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false, // on production make it true
                ValidateAudience = false, // on production make it true
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOption.Issuer,
                ValidAudience = jwtOption.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Key),
                ClockSkew = TimeSpan.Zero
            };

            o.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                    }

                    return Task.CompletedTask;
                },
                OnChallenge = context =>
                {
                    return Task.CompletedTask;
                },
                OnForbidden = (context) =>
                {
                    return Task.CompletedTask;
                },
                OnTokenValidated = async context =>
                {
                    if (context.SecurityToken is JwtSecurityToken accessToken)
                    {
                        var requestToken = accessToken.RawData.ToString();
                        var cacheService = (ICacheService) service.BuildServiceProvider().GetService(typeof(ICacheService))!;
                        var emailKey = accessToken.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Email)?.Value;
                        var authenticated = await cacheService.GetAsync<Response.Authenticated>(emailKey);

                        if (authenticated is null || authenticated.AccessToken != requestToken)
                        {
                            context.Response.Headers.Add("IS-TOKEN-REVOKED", "true");
                            context.Fail("Authentication fail. Token has been revoked!");
                        }
                    }
                    else
                    {
                        context.Fail("Authentication fail.");
                    }
                    await Task.CompletedTask;
                }
            };

            // o.EventsType = typeof(CustomJwtBearerEvents);
        });
        ;
        service.AddAuthorization();
        service.AddScoped<CustomJwtBearerEvents>();
    }
}