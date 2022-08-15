namespace UI.Framework;

[Binding]
public class WebDriverSetup
{
    private readonly ScenarioContext _context;

    public WebDriverSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 4)]
    public void SetUpTflWebDriver() => _context.Set(new TflWebDriver(_context.Get<FrameworkConfig>()));
}
