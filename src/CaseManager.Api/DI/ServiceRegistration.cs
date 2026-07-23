using CaseManager.Application.Interfaces;
using CaseManager.Application.Services;
using CaseManager.Infrastructure.Cache;
using CaseManager.Infrastructure.Repositories;
using StackExchange.Redis;

namespace CaseManager.Api.DI;

public static class ServiceRegistration
{
    public static void AddCaseManagerServices(this IServiceCollection services , IConfiguration config)
    {
        var redisConnection = config.GetSection("Redis")["ConnectionString"];
        services.AddSingleton<IConnectionMultiplexer>(
            ConnectionMultiplexer.Connect(redisConnection));

        services.AddScoped<ICacheClient, RedisCacheClient>();
        services.AddSingleton<ICaseRepository, CaseRepository>();
        services.AddScoped<ICaseSearchService, CaseSearchService>();
    }
}