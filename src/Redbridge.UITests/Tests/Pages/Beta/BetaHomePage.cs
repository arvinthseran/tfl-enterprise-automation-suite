namespace Redbridge.UITests.Tests.Pages.Beta;

public class BetaHomePage : RedbridgeBasePage
{
    private readonly ISearchAddressPage searchAddressPage;

    public BetaHomePage(ScenarioContext context, ISearchAddressPage searchAddressPage) : base(context)
    {
        this.searchAddressPage = searchAddressPage;
    }

    private static By Textarea => By.CssSelector("textarea");

    private static By ContinueButton => By.CssSelector("#btnContinue");

    protected override By PageHeader => By.CssSelector(".govuk-heading-l");

    protected override string PageTitle => "Provide details about the property";

    public BetaSummaryPage SearchAddress()
    {
        searchAddressPage.SearchAddress();

        enterpriseWebdriver.EnterText(Textarea, "Optional details about the property");

        enterpriseWebdriver.Click(ContinueButton);

        return new BetaSummaryPage(context);
    }
}
