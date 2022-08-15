using UI.Framework.Support;

namespace Tfl.UITests.Support;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _context;

    public Hooks(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 21)]
    public void SetUpHelpers() => _context.Set(new DataHelpers());

    [BeforeScenario(Order = 22)]
    public void NavigateTo()
    {
        var projectConfig = _context.Get<ProjectConfig>();

        var tflWebDriver = _context.Get<TflWebDriver>();

        tflWebDriver.GoToUrl(projectConfig.BaseUrl);
    }
}
