using System.Collections;
using System.Collections.ObjectModel;
using Domain.Models;
using Infrastructure.Messaging.SSE.Abstraction;
using JobManagementSystem.Selenium.Abstraction.Template;
using OpenQA.Selenium;
using Job = Infrastructure.Messaging.SSE.Job;

namespace JobManagementSystem.Selenium.Core;

public class ParsingTemplate:IParsingTemplate
{
    private readonly  IWebDriver _driver;
    
    private ISSENotifier<NotificationBase> _notifier;

    public bool IsNotificationsAllowed { get; set; } = true;

    private const int _pagesParsingLimit = 3;
    
    public ParsingTemplate(IWebDriver driver,ISSENotifier<NotificationBase> notifier)
    {
        _driver = driver;
        _notifier = notifier;
    }

    public void Parse()
    {
        try
        {
           
            _driver.Url = "https://zhy.dcz.gov.ua/userSearch/vacancy";
            
            
            Thread.Sleep(5000);
            
            var pagesCountText = _driver
                .FindElement(By.CssSelector(".el-pagination"))
                .FindElement(By.TagName("ul"))
                .FindElements(By.TagName("li"))[^1].Text;
            
            var pagesCount = int.Parse(pagesCountText);

            
            if (pagesCount > _pagesParsingLimit)
            {
                pagesCount = _pagesParsingLimit;
            }

            var totalItems = pagesCount * 4;
            
            for(var i=0;i<pagesCount;i++)
            {
                
                GoToUrl(i);

                Thread.Sleep(5000);

                var jobs = GetJobs();
                
                for (var j=0;i<jobs.Count; j++)
                {
                    var job = jobs[j];
                    
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", job);

                    var jobTitle = job
                        .FindElement(By.CssSelector(".abbr-card-content-container-long"))
                        .Text;
                
                    var salary = job
                        .FindElement(By.CssSelector(".abbr-card-salary-container"))
                        .Text;
                    
                    if (IsNotificationsAllowed)
                    {
                        var parsedPercents = (i+1)*100/totalItems;
                        
                        _notifier.Notify(new GenericNotification<int>()
                        {
                            Message = $"Parsed {parsedPercents}%",
                            Value = parsedPercents
                        });
                    }
                    
                }
                if (IsNotificationsAllowed)
                {
                    _notifier.Notify(new Notification()
                    {
                        Description = $"{i} of {pagesCount} pages parsed",
                    });
                }
            }
            
           
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
           _driver.Close();
           _driver.Quit();
        }
    }

    private ReadOnlyCollection<IWebElement> GetJobs()
    {
        return _driver
            .FindElements(By.CssSelector(".el-col.el-col-24.el-col-xs-24.el-col-sm-16"))[1]
            .FindElements(By.XPath("./div"))[1]
            .FindElements(By.XPath("./*"))[0]
            .FindElements(By.XPath("./*"));
    }

    private void GoToUrl(int number)
    {
        _driver.Navigate().GoToUrl($"https://zhy.dcz.gov.ua/userSearch/vacancy?activePage={number+1}");
    }
}