using JobManagementSystem.Selenium.Options;

namespace JobManagementSystem.Selenium.Abstraction.Template;

public interface IParsingTemplate
{
    public void Parse();

    public void ApplyOptions(ParsingAppOption options);
}