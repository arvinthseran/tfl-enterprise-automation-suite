namespace UI.Framework;

[Binding]
public class DisposeWebDriverTeardown
{
    private readonly ScenarioContext _context;

    public DisposeWebDriverTeardown(ScenarioContext context) => _context = context;

    [AfterScenario(Order = 19)]
    public void DisposeWebDriver() => _context.Get<EnterpriseWebDriver>().Dispose();
}
