namespace Tfl.Framework;

[Binding]
public class FrameworkConfigurationSetup
{
    private readonly ScenarioContext _context;
    
    private readonly IConfigSection _configSection;

    private const string ChromeDriverServiceName = "chromedriver.exe";
    private const string FirefoxDriverServiceName = "geckodriver.exe";

    public FrameworkConfigurationSetup(ScenarioContext context)
    {
        _context = context;
        _configSection = context.Get<IConfigSection>(); 
    }

    [BeforeScenario(Order = 2)]
    public void SetUpFrameworkConfiguration()
    {
        var frameworkConfig = _configSection.GetConfigSection<FrameworkConfig>();

        frameworkConfig.ChromeDriverLocation = FindChromeDriverServiceLocation();

        frameworkConfig.FirefoxDriverLocation = FindFireFoxDriverServiceLocation();

        frameworkConfig.Scenariotags = _context.ScenarioInfo.Tags;

        _context.Set(frameworkConfig);
    }

    private static string FindChromeDriverServiceLocation() => IsPipelineExecution() ? Configurator.ChromeWebDriver : FindLocalDriverServiceLocation(ChromeDriverServiceName);

    private static string FindFireFoxDriverServiceLocation() => IsPipelineExecution() ? Configurator.GeckoWebDriver : FindLocalDriverServiceLocation(FirefoxDriverServiceName);

    private static string FindLocalDriverServiceLocation(string executableName)
    {
        var driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        FileInfo[] file = Directory.GetParent(Directory.GetParent(driverPath).FullName).GetFiles(executableName, SearchOption.AllDirectories);

        return file.Length != 0 ? file.Last().DirectoryName : driverPath;
    }

    private static bool IsPipelineExecution() => Configurator.IsPipelineExecution;
}
