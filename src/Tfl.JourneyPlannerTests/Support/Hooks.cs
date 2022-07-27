namespace Tfl.JourneyPlannerTests.Support;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _context;

    public Hooks(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 21)]
    public void NavigateTo() 
    {
        var projectConfig = _context.Get<ProjectConfig>();

        var webDriver = _context.Get<IWebDriver>();

        webDriver.Navigate().GoToUrl(projectConfig.BaseUrl);
    }
}
