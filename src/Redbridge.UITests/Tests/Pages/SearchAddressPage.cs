namespace Redbridge.UITests.Tests.Pages;


public interface ISearchAddressPage
{
    void SearchInValidAddress(string postcode);

    void SearchValidAddress(string postcode);
}


public class SearchAddressPage : RedbridgeBasePage, ISearchAddressPage
{

    private static By NoAddressFound => By.CssSelector(".no-address-found");

    private static By SearchAddressSelector => By.CssSelector(".searchAddress");

    private static By SearchAddressButton => By.CssSelector(".searchAddressButton");

    private static By AddressListHolder => By.CssSelector(".returnedAddresses li");

    protected override By PageHeader => By.CssSelector(".input-append label");

    protected override string PageTitle => "Street or Postcode";

    public SearchAddressPage(ScenarioContext context, bool verifyPage) : base(context, verifyPage)
    {

    }

    public void SearchValidAddress(string postcode)
    {
        SearchAddress(postcode);

        enterpriseWebdriver.FindEnabledAndDisplayedElement(AddressListHolder);

        var address = testDataHelper.GetRandomElementFromListOfElements(webDriver.FindElements(AddressListHolder).ToList());

        address.Click();
    }

    public void SearchInValidAddress(string postcode)
    {
        SearchAddress(postcode);

        VerifyPage(NoAddressFound, "We could not locate any matching addresses.");
    }

    private void SearchAddress(string postcode)
    {
        enterpriseWebdriver.EnterText(SearchAddressSelector, postcode);

        objectContext.Set("postcode", postcode);

        enterpriseWebdriver.Click(SearchAddressButton);
    }
}
