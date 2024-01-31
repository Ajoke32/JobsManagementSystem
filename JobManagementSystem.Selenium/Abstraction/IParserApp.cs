using JobManagementSystem.Selenium.Options;

namespace JobManagementSystem.Selenium.Abstraction;

public interface IParserApp
{
    public void Start();

    public Task StartAsync();

    public void ConfigureParsingOptions(Func<ParsingAppOption,ParsingAppOption> action);
}