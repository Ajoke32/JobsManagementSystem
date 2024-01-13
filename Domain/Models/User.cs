namespace Domain.Models;

public class User
{
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string JobPosition { get; set; } = string.Empty;
    
    public bool IsNotificationsAllowed { get; set; }

    public bool IsEmailMailingAllowed { get; set; }
}