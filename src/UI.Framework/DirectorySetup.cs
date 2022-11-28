using ConfigurationBuilder;

namespace UI.Framework;

[Binding]
public class DirectorySetup
{
    private readonly ObjectContext _objectContext;
    private readonly FeatureContext _featureContext;
    private readonly ScenarioContext _context;

    public DirectorySetup(ScenarioContext context, FeatureContext featureContext)
    {
        _context = context;
        _featureContext = featureContext;
        _objectContext = context.Get<ObjectContext>();
    }

    [BeforeScenario(Order = 3)]
    public void SetUpDirectory()
    {
        string directory = GetDirectoryPath();

        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

        _context.Get<FrameworkConfig>().TestAttachmentsDirectoryPath = directory;

        _objectContext.SetDirectory(directory);
    }

    private string GetDirectoryPath()
    {
        string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestAttachments", $"{DateTime.Now:dd-MM-yyyy}", $"{DirectoryEscapePattern(_featureContext.FeatureInfo.Title)}_{DateTime.Now:HHmmss}");

        return Path.GetFullPath(directory);
    }

    public static string DirectoryEscapePattern(string value) => Regex.Replace(value, @"<|>|:", string.Empty);
}