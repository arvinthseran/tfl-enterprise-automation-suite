namespace Redbridge.UITests.Support;


[Binding]
public class ProjectConfigSetUp
{
    private readonly ScenarioContext _context;

    public ProjectConfigSetUp(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 20)]
    public void SetUpProjectConfig() => _context.Set(_context.Get<IConfigSection>().GetConfigSection<ProjectConfig>());
}
