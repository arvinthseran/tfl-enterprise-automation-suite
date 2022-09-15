using OpenQA.Selenium;

namespace Pantheon.UITests.Tests.Pages;

public class LandingPage : TopMenuBasePage
{
    protected override By PageHeader => By.CssSelector(".banner-text");

    protected override string PageTitle => "Investing Responsibly";

    public LandingPage(ScenarioContext context) : base(context)
    {

    }
}
