namespace CaseManager.Application.DTOs;

public class FirResponse
{
    public Guid FirId { get; set; }
    public string FirNumber { get; set; }
    public string CrimeType { get; set; }
    public string ComplainantName { get; set; }
    public string StationId { get; set; }
    public string StateCode { get; set; }
    public DateTime CreatedAt { get; set; }
}