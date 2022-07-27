using NUnit.Framework;
namespace Tfl.Framework.Support;

public class TflWebDriver
{
    private readonly IWebDriver _webDriver;
    private readonly FrameworkConfig _frameworkConfig;

    public TflWebDriver(FrameworkConfig frameworkConfig)
    {
        _frameworkConfig = frameworkConfig;
        _webDriver = new WebDriverSetupHelper(_frameworkConfig).SetUpWebDriver();
    }

    public void TakeScreenShot(string pageTitle)
    {
        var imageName = $"{DateTime.Now:HH-mm-ss}_{pageTitle}.png".RemoveSpace();

        string screenshotPath = _frameworkConfig.TestAttachmentsDirectoryPath;

        try
        {
            ITakesScreenshot screenshotHandler = _webDriver as ITakesScreenshot;
            Screenshot screenshot = screenshotHandler.GetScreenshot();
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(screenshotPath, imageName);
        }
        catch (Exception exception)
        {
            TestContext.Progress.WriteLine($"Exception occurred while taking screenshot - Path - '{screenshotPath}', ImageName - '{imageName}'" + exception);
        }
    }

    public void Dispose()
    {
        _webDriver?.Quit();
        _webDriver?.Dispose();
    }

    public void GoToUrl(string url) => _webDriver.Navigate().GoToUrl(url);

    public IWebElement FindElement(By by) => _webDriver.FindElement(by);

    public IWebElement FindEnabledAndVisibleElement(By by)
    {
        return WebDriverWait().Until((driver) => 
        {
            var x = driver.FindElement(by);

            if (x.Enabled && x.Displayed) return x;

            throw new NotFoundException();
        });
    }

    private WebDriverWait WebDriverWait() => new(_webDriver, TimeSpan.FromSeconds(_frameworkConfig.ExplicitWait));
}
