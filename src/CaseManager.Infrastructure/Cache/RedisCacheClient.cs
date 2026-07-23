using StackExchange.Redis;
using System.Text.Json;

namespace CaseManager.Infrastructure.Cache;

public interface ICacheClient
{
    Task<string> GetAsync(string key);
    Task SetAsync(string key, object value, TimeSpan ttl);
}

public class RedisCacheClient : ICacheClient
{
    private readonly IDatabase _db;

    public RedisCacheClient(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    public async Task<string> GetAsync(string key)
    {
        return await _db.StringGetAsync(key);
    }

    public async Task SetAsync(string key, object value, TimeSpan ttl)
    {
        var json = JsonSerializer.Serialize(value);
        await _db.StringSetAsync(key, json, ttl);
    }
}