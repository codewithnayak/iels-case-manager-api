namespace CaseManager.Domain.Entities;

public class FirSequence
{
    public string StationId { get; set; }
    public long CurrentValue { get; set; }
    public int Year { get; set; }
}