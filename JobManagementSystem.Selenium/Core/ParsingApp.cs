using JobManagementSystem.Selenium.Abstraction;
using JobManagementSystem.Selenium.Abstraction.Template;
using JobManagementSystem.Selenium.Options;
using OpenQA.Selenium;

namespace JobManagementSystem.Selenium.Core;

public class ParsingApp:IParserApp
{
    private readonly  IParsingTemplate _template;
    
    private readonly IWebDriver  _driver;

    private ParsingAppOption _options;
    
    public ParsingApp(IParsingTemplate template, IWebDriver driver)
    {
        _template = template;
        _driver = driver;
    }

    public void ConfigureParsingOptions(Func<ParsingAppOption,ParsingAppOption> action)
    {
        _options = action(new ParsingAppOption());
    }
    
    public void Start()
    {
        _template.ApplyOptions(_options);
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