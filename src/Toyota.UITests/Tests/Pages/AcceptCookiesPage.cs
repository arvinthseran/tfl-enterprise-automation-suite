namespace Toyota.UITests.Tests.Pages;

public class AcceptCookiesPage : ProjectBasePage
{
    public AcceptCookiesPage(ScenarioContext context) : base(context)
    {

    }


    protected override By PageHeader => By.CssSelector("#onetrust-policy-title");

    protected override string PageTitle => "WE USE WEBSITE COOKIES";

    private static By AcceptCookiesSelector => By.CssSelector("#onetrust-accept-btn-handler");

    public void AcceptCookies() => enterpriseWebdriver.FindElement(AcceptCookiesSelector).Click();
}
