namespace JobManagementSystem.Selenium.Abstraction.Factories;

public interface IAppFactory
{
    public IParserApp CreateInstance<T>() where T:IParserApp;
}