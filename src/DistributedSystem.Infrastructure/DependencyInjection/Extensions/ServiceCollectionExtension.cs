using DistributedSystem.Application.Abstractions;
using DistributedSystem.Infrastructure.Authentication;
using DistributedSystem.Infrastructure.Authentication.Services;
using DistributedSystem.Infrastructure.Caching.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DistributedSystem.Infrastructure.DependencyInjection.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddServiceInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<IJwtTokenService, JwtTokenService>();
        service.AddScoped<ICacheService, CacheService>();
    }

    public static void AddRedisServiceInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(redisOptions =>
        {
            var connectionString = configuration.GetConnectionString("Redis");
            redisOptions.Configuration = connectionString;
        });
    }
}