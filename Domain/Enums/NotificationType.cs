namespace Domain.Enums;

[Flags]
public enum NotificationType
{
    Success,
    Fail,
    Terminated,
    Finished,
    WithValue
}

