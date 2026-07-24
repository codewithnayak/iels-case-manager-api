using CaseManager.Domain.Entities;
using CaseManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CaseManager.Infrastructure.Services;

public interface IFirSequenceService
{
    Task<long> GetNextSequenceAsync(string stationId);
}

public class FirSequenceService : IFirSequenceService
{
    private readonly CaseDbContext _db;

    public FirSequenceService(CaseDbContext db)
    {
        _db = db;
    }

    public async Task<long> GetNextSequenceAsync(string stationId)
    {
        var year = DateTime.UtcNow.Year;

        var seq = await _db.FirSequences
            .Where(x => x.StationId == stationId && x.Year == year)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(x => x.CurrentValue, x => x.CurrentValue + 1));

        var updated = await _db.FirSequences
            .Where(x => x.StationId == stationId && x.Year == year)
            .Select(x => x.CurrentValue)
            .FirstAsync();

        return updated;
    }
}