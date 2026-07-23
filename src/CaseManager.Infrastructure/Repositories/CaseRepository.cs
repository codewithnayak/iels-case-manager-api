using System.Text.Json;
using CaseManager.Domain.Entities;

namespace CaseManager.Infrastructure.Repositories;

public interface ICaseRepository
{
    Task<IEnumerable<Case>> SearchCasesAsync(string crimeType, string status, string officer);
}

public class CaseRepository : ICaseRepository
{
    private readonly List<Case> _cases;

    public CaseRepository()
    {
        var json = File.ReadAllText("data/cases.json");
        _cases = JsonSerializer.Deserialize<List<Case>>(json);
    }

    public async  Task<IEnumerable<Case>> SearchCasesAsync(string crimeType, string status, string officer)
    {
        var query = _cases.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(crimeType))
            query = query.Where(c => c.CrimeType.Contains(crimeType, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(status))
            query = query.Where(c => c.Status.Equals(status, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(officer))
            query = query.Where(c => c.Officer.Contains(officer, StringComparison.OrdinalIgnoreCase));

        return await Task.FromResult(query);
    }
}