using CaseManager.Application.Interfaces;
using CaseManager.Application.Services;
using CaseManager.Application.Validators;
using CaseManager.Infrastructure.Cache;
using CaseManager.Infrastructure.Persistence;
using CaseManager.Infrastructure.Repositories;
using CaseManager.Infrastructure.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
        services.AddValidatorsFromAssembly(typeof(CaseSearchRequestValidator).Assembly);
        
        // PostgreSQL
        var connectionString = config.GetConnectionString("Postgres");
        services.AddDbContext<CaseDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddDbContext<CaseDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("Postgres")));

        services.AddScoped<IFirRepository, FirRepository>();
        services.AddScoped<IFirService, FirService>();
        services.AddScoped<IFirSequenceService, FirSequenceService>();
        services.AddScoped<IFirNumberGenerator, FirNumberGenerator>();

        services.AddValidatorsFromAssembly(typeof(CreateFirRequestValidator).Assembly);


    }
}