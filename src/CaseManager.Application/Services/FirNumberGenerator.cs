using CaseManager.Infrastructure.Services;

namespace CaseManager.Application.Services;

public interface IFirNumberGenerator
{
    Task<string> GenerateAsync(string stateCode, string stationCode);
}

public class FirNumberGenerator : IFirNumberGenerator
{
    private readonly IFirSequenceService _sequenceService;

    public FirNumberGenerator(IFirSequenceService sequenceService)
    {
        _sequenceService = sequenceService;
    }

    public async Task<string> GenerateAsync(string stateCode, string stationCode)
    {
        var year = DateTime.UtcNow.Year;
        var seq = await _sequenceService.GetNextSequenceAsync(stationCode);

        return $"{stateCode}-{stationCode}-{year}-{seq:D6}";
    }
}