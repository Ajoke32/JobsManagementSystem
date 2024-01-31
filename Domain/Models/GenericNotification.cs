namespace Domain.Models;

public class GenericNotification<T>:NotificationBase
{
    public string Description { get; set; } = string.Empty;
    
    public T Value { get; set; }

    public GenericNotification(T value,string message,string description)
    {
        Value = value;
        Message = message;
        Description = description;
    }

    public GenericNotification()
    {

    }
}