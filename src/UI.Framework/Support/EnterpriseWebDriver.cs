namespace UI.Framework.Support;

public class EnterpriseWebDriver
{
    private readonly IWebDriver _webDriver;
    private readonly FrameworkConfig _frameworkConfig;
    private readonly WebDriverSetupHelper _webDriverSetupHelper;


    public EnterpriseWebDriver(FrameworkConfig frameworkConfig)
    {
        _frameworkConfig = frameworkConfig;
        _webDriverSetupHelper = new WebDriverSetupHelper(_frameworkConfig);
        _webDriver = _webDriverSetupHelper.SetUpWebDriver();
    }

    public void SelectByText(By by, string text) => new SelectElement(FindEnabledElement(by)).SelectByText(text);

    public string GetText(By by) => FindEnabledElement(by).Text;

    public string GetEnabledAndDisplayedElementText(By by) => FindEnabledElement(by).Text;

    public void Click(By by) => FindEnabledElement(by).Click();

    public void EnterText(By by, string text, bool pressTab = true)
    {
        var x = FindElement(by);

        x.Clear();
        x.SendKeys(text);

        if (pressTab) x.SendKeys(Keys.Tab);
    }

    public void TakeScreenShot(string pageTitle)
    {
        var imageName = $"{DateTime.Now:HH-mm-ss}_{pageTitle}.png".RemoveSpace();

        string screenshotPath = Combine(_frameworkConfig.TestAttachmentsDirectoryPath, imageName);

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

    public List<IWebElement> TryToFindNotVisibleElements(By by)
    {
        _webDriverSetupHelper.SetImplicitWait(_webDriver, TimeSpan.FromMilliseconds(500));

        var result = _webDriver.FindElements(by).ToList();

        _webDriverSetupHelper.SetImplicitWait(_webDriver);

        return result;
    }

    public IWebElement FindElement(By by) => _webDriver.FindElement(by);

    public IWebElement FindEnabledAndDisplayedElement(By by) => FindElement(by, (x) => x.Enabled && x.Displayed);

    public IWebElement FindEnabledElement(By by) => FindElement(by, (x) => x.Enabled);

    internal IWebDriver GetWebDriver() => _webDriver;

    private IWebElement FindElement(By by, Func<IWebElement, bool> func)
    {
        var wait = WebDriverWait();

        wait.PollingInterval = TimeSpan.FromMilliseconds(1000);

        return wait.Until((driver) =>
        {
            var x = driver.FindElement(by);

            if (func(x)) return x;

            throw new NotFoundException(by.ToString());
        });
    }

    private WebDriverWait WebDriverWait() => new(_webDriver, TimeSpan.FromSeconds(_frameworkConfig.ExplicitWait));

    private static string Combine(string screenshotsDirectory, string imageName)
    {
        var screenshotPath = Path.Combine(screenshotsDirectory, imageName);

        return Path.GetFullPath(screenshotPath);
    }
}
