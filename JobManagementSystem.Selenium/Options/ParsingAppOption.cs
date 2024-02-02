using Domain.Enums;

namespace JobManagementSystem.Selenium.Options;

public class ParsingAppOption
{
    public bool SendNotifications { get; set; }
    
    public bool SendPercentageNotification { get; set; }
    
    public bool SendParsedPagesNotification { get; set; }
    
    public int DelayMs { get; set; }
    
    public DelayType DelayType { get; set; }
    
    public int MaxPages { get; set; }
    
    public int ItemsPerPage { get; set; }

    public bool IsItemsReceivingEnabled { get; set; }
}