using Redbridge.UITests.Tests.Pages;

namespace Redbridge.UITests.Support;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _context;

    public Hooks(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 22)]
    public void SetUpHelpers()
    {
        var projectConfig = _context.Get<ProjectConfig>();

        var webDriver = _context.Get<EnterpriseWebDriver>();

        _context.Set(new TestDataHelper());

        if (_context.ScenarioInfo.Tags.Contains("beta")) webDriver.GoToUrl(projectConfig.BetaUrl);

        else webDriver.GoToUrl(projectConfig.BaseUrl);

    }
}
