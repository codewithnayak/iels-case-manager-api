
namespace CaseManager.Domain.Entities;

public class Case
{
    public string CaseId { get; set; }
    public string CrimeType { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Officer { get; set; }
    public string StationId { get; set; }
}
