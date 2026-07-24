using CaseManager.Domain.Entities;
using CaseManager.Infrastructure.Persistence;

namespace CaseManager.Infrastructure.Repositories;

public interface IFirRepository
{
    Task<Fir> AddAsync(Fir fir);
}

public class FirRepository : IFirRepository
{
    private readonly CaseDbContext _db;

    public FirRepository(CaseDbContext db)
    {
        _db = db;
    }

    public async Task<Fir> AddAsync(Fir fir)
    {
        _db.Firs.Add(fir);
        await _db.SaveChangesAsync();
        return fir;
    }
}