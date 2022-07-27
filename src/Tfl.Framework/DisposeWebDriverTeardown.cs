namespace Tfl.Framework;

[Binding]
public class DisposeWebDriverTeardown
{
    private readonly ScenarioContext _context;

    public DisposeWebDriverTeardown(ScenarioContext context) => _context = context;

    [AfterScenario(Order = 19)]
    public void DisposeWebDriver() 
    {
        var WebDriver = _context.Get<IWebDriver>();

        WebDriver?.Quit();
        WebDriver?.Dispose();
    }
}
