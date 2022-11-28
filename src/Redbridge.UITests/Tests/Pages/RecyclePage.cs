namespace Redbridge.UITests.Tests.Pages;


public class RecyclePage : RedbridgeBasePage
{
    private readonly ISearchAddressPage searchaddressPage;

    public RecyclePage(ScenarioContext context, ISearchAddressPage searchaddressPage) : base(context)
    {
        this.searchaddressPage = searchaddressPage;
    }

    private static By YourCollections => By.CssSelector(".your-collection-schedule-container");

    protected override By PageHeader => By.CssSelector(".page-header");

    protected override string PageTitle => "Recycling and Refuse";

    public RecyclePage SearchAddress()
    {
        searchaddressPage.SearchValidAddress(testDataHelper.ValidPostcode);

        return new RecyclePage(context, new SearchAddressPage(context, false));
    }
    
    public void VerifyYourCollections() => VerifyPage(YourCollections, "Your collections");
}
