using Domain.Enums;

namespace Domain.Models;

public class NotificationBase
{
    public NotificationType NotificationType { get; set; }

    public string Message { get; set; } = string.Empty;
}