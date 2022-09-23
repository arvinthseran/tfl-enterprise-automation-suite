using UI.Framework.Support;

namespace LeedsCityCouncil.UITests.Support;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _context;

    public Hooks(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 22)]
    public void NavigateTo()
    {
        var projectConfig = _context.Get<ProjectConfig>();

        var webDriver = _context.Get<EnterpriseWebDriver>();

        webDriver.GoToUrl(projectConfig.BaseUrl);
    }
}
