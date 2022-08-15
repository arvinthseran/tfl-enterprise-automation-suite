namespace UI.Framework;

[Binding]
public class WebDriverSetup
{
    private readonly ScenarioContext _context;

    public WebDriverSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 4)]
    public void SetUpWebDriver() => _context.Set(new EnterpriseWebDriver(_context.Get<FrameworkConfig>()));
}
