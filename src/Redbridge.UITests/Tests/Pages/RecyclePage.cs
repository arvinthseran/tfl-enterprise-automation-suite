using ConfigurationBuilder;

namespace Redbridge.UITests.Tests.Pages;


public class RecyclePage : RedbridgeBasePage
{
    public RecyclePage(ScenarioContext context): base(context)
    {

    }

    private static By SearchAddress => By.CssSelector(".searchAddress");

    private static By SearchAddressButton => By.CssSelector(".searchAddressButton");

    private static By AddressListHolder => By.CssSelector("#AddressListHolder li");

    private static By YourCollections => By.CssSelector(".your-collection-schedule-container");

    protected override By PageHeader => By.CssSelector(".page-header");

    protected override string PageTitle => "Recycling and Refuse";

    public RecyclePage EnterAddress()
    {
        var postcode = testDataHelper.Postcode;

        enterpriseWebdriver.EnterText(SearchAddress, postcode);

        objectContext.Set("postcode", postcode);

        enterpriseWebdriver.Click(SearchAddressButton);

        enterpriseWebdriver.FindEnabledAndDisplayedElement(AddressListHolder);

        var address = testDataHelper.GetRandomElementFromListOfElements(webDriver.FindElements(AddressListHolder).ToList());

        address.Click();

        return new RecyclePage(context);
    }
    
    public void VerifyYourCollections() => VerifyPage(YourCollections, "Your collections");
}
