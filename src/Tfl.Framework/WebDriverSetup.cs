namespace Tfl.Framework;

[Binding]
public class WebDriverSetup
{
    private readonly ScenarioContext _context;

    private FrameworkConfig _frameworkConfig;

    public WebDriverSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 3)]
    public void SetUpWebDriver()
    {
        _frameworkConfig = _context.Get<FrameworkConfig>();

        var webDriver = new WebDriverSetupHelper(_frameworkConfig).GetWebDriver();

        webDriver.Manage().Window.Maximize();
        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_frameworkConfig.ImplicitWait);
        webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_frameworkConfig.PageLoad);
        webDriver.Manage().Cookies.DeleteAllCookies();

        webDriver.SwitchTo().Window(webDriver.CurrentWindowHandle);

        _context.Set<IWebDriver>(webDriver);
    }

  
}
