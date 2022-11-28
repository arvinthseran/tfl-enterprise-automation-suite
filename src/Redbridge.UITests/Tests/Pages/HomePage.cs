namespace Redbridge.UITests.Tests.Pages;


public class HomePage : RedbridgeBasePage
{
    public HomePage(ScenarioContext context) : base(context, false) => VerifyPage(PageHeader, PageTitle, (x) => x.GetAttribute("alt"));

    private static By BinsSelector => By.CssSelector("a[href*='bins-waste-and-recycling']");

    protected override By PageHeader => By.CssSelector(".navbar-header a > img");

    protected override string PageTitle => "London Borough of Redbridge";

    public BinsPage GoToBins()
    {
        enterpriseWebdriver.Click(BinsSelector);
        return new BinsPage(context);
    }
}
