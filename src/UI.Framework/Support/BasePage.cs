using NUnit.Framework;

namespace UI.Framework.Support;

public abstract class BasePage
{
    protected abstract By PageHeader { get; }

    protected abstract string PageTitle { get; }

    protected readonly EnterpriseWebDriver enterpriseWebdriver;

    protected readonly IWebDriver webDriver;

    protected readonly ScenarioContext context;

    public BasePage(ScenarioContext context, bool verifyPage = true)
    {
        this.context = context;

        enterpriseWebdriver = context.Get<EnterpriseWebDriver>();

        webDriver = enterpriseWebdriver.GetWebDriver();

        if (verifyPage) VerifyPage();
    }

    protected void VerifyPage(By by, string expected) => VerifyPage(by, expected, (x) => x.Text);
    
    protected void VerifyPage(By by, string expected, Func<IWebElement, string> func)
    {
        try
        {
            RetryOnException(() =>
            {
                var actual = func(enterpriseWebdriver.FindElement(by));

                VerifyPage(actual, expected);
            });

        }
        finally
        {
            enterpriseWebdriver.TakeScreenShot(expected);
        }
    }

    private static void VerifyPage(string actual, string expected)
    {
        string message = $"Page verification failed: {Environment.NewLine}Expected: {expected} {Environment.NewLine}Actual: {actual}";

        Assert.That(actual.Contains(expected, StringComparison.OrdinalIgnoreCase), message);
    }

    protected void VerifyPage() => VerifyPage(PageHeader, PageTitle);

    internal static void RetryOnException(Action action)
    {
        Policy
            .Handle<Exception>()
            .WaitAndRetry(new TimeSpan[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3) })
            .Execute(() =>
             {
                 using var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext();
                 action();
             });
    }
}
