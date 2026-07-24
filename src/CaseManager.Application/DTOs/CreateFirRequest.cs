namespace CaseManager.Application.DTOs;

public class CreateFirRequest
{
    public string ComplainantName { get; set; }
    public string ComplainantPhone { get; set; }
    public string Address { get; set; }
    public string CrimeType { get; set; }
    public DateTime IncidentDateTime { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }

    public string StationId { get; set; }
    public string StateCode { get; set; }
    public string CreatedBy { get; set; }
}