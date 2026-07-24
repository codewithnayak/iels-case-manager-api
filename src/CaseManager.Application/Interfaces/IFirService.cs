using CaseManager.Application.DTOs;

namespace CaseManager.Application.Interfaces;

public interface IFirService
{
    Task<FirResponse> CreateFirAsync(CreateFirRequest request);
}