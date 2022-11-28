namespace Redbridge.UITests.Tests.Pages.Beta;

public class BetaSummaryPage : RedbridgeBasePage
{

    private static By AddressDetails => By.CssSelector("#address");

    public BetaSummaryPage(ScenarioContext context) : base(context)
    {

    }

    protected override By PageHeader => By.CssSelector("h1");

    protected override string PageTitle => "Summary";

    public void VerifyAddressDetails() => VerifyPage(AddressDetails, testDataHelper.Postcode);
}
