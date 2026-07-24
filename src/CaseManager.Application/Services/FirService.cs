using CaseManager.Application.DTOs;
using CaseManager.Application.Interfaces;
using CaseManager.Domain.Entities;
using CaseManager.Infrastructure.Repositories;

namespace CaseManager.Application.Services;

public class FirService : IFirService
{
    private readonly IFirRepository _repo;
    private readonly IFirNumberGenerator _firNumberGenerator;

    public FirService(IFirRepository repo, IFirNumberGenerator firNumberGenerator)
    {
        _repo = repo;
        _firNumberGenerator = firNumberGenerator;
    }

    public async Task<FirResponse> CreateFirAsync(CreateFirRequest request)
    {
        var firNumber = await _firNumberGenerator.GenerateAsync(
            request.StateCode,
            request.StationId
        );

        var fir = new Fir
        {
            FirId = Guid.NewGuid(),
            FirNumber = firNumber,
            ComplainantName = request.ComplainantName,
            ComplainantPhone = request.ComplainantPhone,
            Address = request.Address,
            CrimeType = request.CrimeType,
            IncidentDateTime = request.IncidentDateTime,
            Location = request.Location,
            Description = request.Description,
            StationId = request.StationId,
            StateCode = request.StateCode,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        await _repo.AddAsync(fir);

        return new FirResponse
        {
            FirId = fir.FirId,
            FirNumber = fir.FirNumber,
            CrimeType = fir.CrimeType,
            ComplainantName = fir.ComplainantName,
            StationId = fir.StationId,
            StateCode = fir.StateCode,
            CreatedAt = fir.CreatedAt
        };
    }
}