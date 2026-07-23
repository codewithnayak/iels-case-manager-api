using CaseManager.Application.DTOs;

namespace CaseManager.Application.Interfaces;

public interface ICaseSearchService
{
    Task<IEnumerable<CaseSearchResultDto>> SearchAsync(string crimeType, string status, string officer);
}
