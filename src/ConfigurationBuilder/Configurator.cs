namespace ConfigurationBuilder;

public static class Configurator
{
    private readonly static IConfigurationRoot _config;

    public readonly static bool IsPipelineExecution;

    public readonly static string ChromeWebDriver;

    public readonly static string GeckoWebDriver;

    static Configurator()
    {
        _config = InitializeConfig();
        IsPipelineExecution = TestsExecutionInAzureDevops();

        // the path to driver location will be mentioned as part of the Environment variables
        //please ref to https://github.com/actions/virtual-environments/blob/win22/20220724.1/images/win/Windows2022-Readme.md

        ChromeWebDriver = GetHostingConfigSection("CHROMEWEBDRIVER");
        GeckoWebDriver = GetHostingConfigSection("GECKOWEBDRIVER");
    }

    internal static IConfigurationRoot GetConfig() => _config;

    private static bool TestsExecutionInAzureDevops() => !string.IsNullOrEmpty(GetHostingConfigSection("AGENT_MACHINENAME"));

    private static IConfigurationRoot InitializeConfig() => new Microsoft.Extensions.Configuration.ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Framework.json")
            .AddJsonFile("appsettings.Project.json", true)
            .AddUserSecrets($"Tfl.JourneyPlannerTest_Secrets")
            .AddEnvironmentVariables()
            .Build();

    private static string GetHostingConfigSection(string name) => _config.GetSection(name)?.Value;
}