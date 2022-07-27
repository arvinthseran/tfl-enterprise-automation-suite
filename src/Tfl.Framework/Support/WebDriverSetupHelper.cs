﻿namespace Tfl.Framework.Support;

public class WebDriverSetupHelper
{
    private readonly FrameworkConfig _frameworkConfig;

    public WebDriverSetupHelper(FrameworkConfig frameworkConfig) => _frameworkConfig = frameworkConfig;

    internal IWebDriver GetWebDriver()
    {
        string browser = _frameworkConfig.Browser;

        return true switch
        {
            _ when browser.IsFirefox() => new FirefoxDriver(_frameworkConfig.FirefoxDriverLocation),
            _ when browser.IsChrome() => new ChromeDriver(_frameworkConfig.ChromeDriverLocation, AddArguments(), TimeSpan.FromMinutes(_frameworkConfig.CommandTimeout)),
            _ => throw new Exception("Driver name - " + browser + " does not match OR this framework does not support the webDriver specified")
        };
    }

    private static ChromeOptions AddArguments()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("no-sandbox");
        chromeOptions.AddArgument("ignore-certificate-errors");
        chromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
        chromeOptions.PageLoadStrategy = PageLoadStrategy.None;
        return chromeOptions;
    }
}
