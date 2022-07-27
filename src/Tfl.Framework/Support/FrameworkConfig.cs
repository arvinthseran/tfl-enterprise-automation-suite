namespace Tfl.Framework.Support;

public class FrameworkConfig
{
    public string Browser { get; init; }

    public int PageLoad { get; init; }

    public int ImplicitWait { get; init; }

    public int ExplicitWait { get; init; }

    public int CommandTimeout { get; init; }

    public string ChromeDriverLocation { get; set; }

    public string FirefoxDriverLocation { get; set; }

    public string TestAttachmentsDirectoryPath { get; set; }

}
