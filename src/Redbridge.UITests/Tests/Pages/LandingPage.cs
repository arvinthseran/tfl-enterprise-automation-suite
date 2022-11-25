namespace Redbridge.UITests.Tests.Pages;

public class LandingPage : BasePage
{
    public LandingPage(ScenarioContext context) : base(context)
    {

    }

    protected override By PageHeader => By.CssSelector("header");

    protected override string PageTitle => "London Borough of Redbridge";
}
