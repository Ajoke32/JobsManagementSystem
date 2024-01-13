namespace Domain.Models;

public class Job
{
    public int Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;
    
    public DateTime PostedDate { get; set; }
}