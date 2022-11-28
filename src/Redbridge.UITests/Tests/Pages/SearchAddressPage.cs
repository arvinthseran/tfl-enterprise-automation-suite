namespace Redbridge.UITests.Tests.Pages;


public interface ISearchAddressPage
{
    void SearchAddress();
}


public class SearchAddressPage : RedbridgeBasePage, ISearchAddressPage
{

    private static By SearchAddressSelector => By.CssSelector(".searchAddress");

    private static By SearchAddressButton => By.CssSelector(".searchAddressButton");

    private static By AddressListHolder => By.CssSelector(".returnedAddresses li");

    protected override By PageHeader => By.CssSelector(".input-append label");

    protected override string PageTitle => "Street or Postcode";

    public SearchAddressPage(ScenarioContext context, bool verifyPage) : base(context, verifyPage)
    {

    }

    public void SearchAddress()
    {
        var postcode = testDataHelper.Postcode;

        enterpriseWebdriver.EnterText(SearchAddressSelector, postcode);

        objectContext.Set("postcode", postcode);

        enterpriseWebdriver.Click(SearchAddressButton);

        enterpriseWebdriver.FindEnabledAndDisplayedElement(AddressListHolder);

        var address = testDataHelper.GetRandomElementFromListOfElements(webDriver.FindElements(AddressListHolder).ToList());

        address.Click();
    }
}
