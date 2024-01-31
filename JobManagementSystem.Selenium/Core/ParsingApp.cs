using JobManagementSystem.Selenium.Abstraction;
using JobManagementSystem.Selenium.Abstraction.Template;
using JobManagementSystem.Selenium.Options;
using OpenQA.Selenium;

namespace JobManagementSystem.Selenium.Core;

public class ParsingApp:IParserApp
{
    private readonly  IParsingTemplate _template;
    
    private readonly IWebDriver  _driver;
    
    public ParsingApp(IParsingTemplate template, IWebDriver driver)
    {
        _template = template;
        _driver = driver;
    }

    public void ConfigureParsingOptions(Func<ParsingAppOption,ParsingAppOption> action)
    {
        action(new ParsingAppOption());
    }
    
    public void Start()
    {
        _template.Parse();
    }

    public async Task StartAsync()
    {
       await Task.Run(() =>
       {
            _template.Parse();
       });
    }
}