namespace Tfl.Framework.Support;

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
        var actual = driver.FindElement(PageHeader).Text;

        driver.TakeScreenShot(PageTitle);

        StringAssert.Contains(PageTitle, actual, $"Page verification failed:" +
            $"{Environment.NewLine}Expected: {PageTitle}" +
            $"{Environment.NewLine}Actual: {actual}");
    }
}
