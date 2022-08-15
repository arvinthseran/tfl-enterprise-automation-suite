namespace UI.Framework.Support;

public abstract class BasePage
{
    protected abstract By PageHeader { get; }

    protected abstract string PageTitle { get; }

    protected readonly TflWebDriver driver;

    protected readonly ScenarioContext context;

    public BasePage(ScenarioContext context, bool verifyPage = true)
    {
        this.context = context;

        driver = context.Get<TflWebDriver>();

        if (verifyPage) VerifyPage();
    }

    protected void VerifyPage()
    {
        driver.TakeScreenShot(PageTitle);

        RetryOnException(() =>
        {
            var actual = driver.FindElement(PageHeader).Text;

            StringAssert.Contains(PageTitle, actual, $"Page verification failed:" +
                $"{Environment.NewLine}Expected: {PageTitle}" +
                $"{Environment.NewLine}Actual: {actual}");
        });
    }

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
