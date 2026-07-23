using CaseManager.Application.DTOs;
using CaseManager.Application.Interfaces;
using CaseManager.Infrastructure.Cache;
using CaseManager.Infrastructure.Repositories;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace CaseManager.Application.Services;

public class CaseSearchService : ICaseSearchService
{
    private readonly ICaseRepository _repo;
    private readonly ICacheClient _cache;
    private readonly ILogger<CaseSearchService> _logger;

    public CaseSearchService(ICaseRepository repo, ICacheClient cache , ILogger<CaseSearchService> logger)
    {
        _repo = repo;
        _cache = cache;
        _logger = logger;
    }

    public async Task<IEnumerable<CaseSearchResultDto>> SearchAsync(string crimeType, string status, string officer)
    {
        var cacheKey = $"cases:search:{crimeType}:{status}:{officer}";
        _logger.LogDebug(cacheKey);
        var cached = await _cache.GetAsync(cacheKey);
        _logger.LogDebug("Cached value: {cached}", cached);
        

        if (!string.IsNullOrEmpty(cached))
        {
            _logger.LogDebug("Response is returned from Redis");
            return JsonSerializer.Deserialize<IEnumerable<CaseSearchResultDto>>(cached);
        }

        var results = await _repo.SearchCasesAsync(crimeType, status, officer);

        var dto = results.Select(c => new CaseSearchResultDto
        {
            CaseId = c.CaseId,
            CrimeType = c.CrimeType,
            Status = c.Status,
            Officer = c.Officer
        });

        await _cache.SetAsync(cacheKey, dto, TimeSpan.FromMinutes(5));

        return dto;
    }
}