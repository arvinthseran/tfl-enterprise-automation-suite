namespace ConfigurationBuilder;

[Binding]
public class ConfigurationSetup
{
    private readonly ScenarioContext _context;

    public ConfigurationSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 1)]
    public void SetUpConfiguration() => _context.Set<IConfigSection>(new ConfigSection(Configurator.GetConfig()));
}
