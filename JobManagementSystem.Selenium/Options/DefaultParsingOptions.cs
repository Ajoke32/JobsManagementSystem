namespace JobManagementSystem.Selenium.Options;

public static class DefaultParsingOptions
{
    public static ParsingAppOption GetDefaultParsingAppOption => new ParsingAppOption()
    {
        MaxPages = 4,
        SendPercentageNotification = false,
        SendParsedPagesNotification = false,
        DelayType = DelayType.ThreadDelay,
        DelayMs = 5000,
        ItemsPerPage = 4,
        SendNotifications = false
    };
}