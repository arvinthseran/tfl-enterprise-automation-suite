using System;
using System.Collections.Generic;
using System.Linq;

namespace Redbridge.UITests.Tests.Pages;

public class RecyclePage : BasePage
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
        enterpriseWebdriver.EnterText(SearchAddress, "IG1 3DE");

        enterpriseWebdriver.Click(SearchAddressButton);

        enterpriseWebdriver.FindEnabledAndDisplayedElement(AddressListHolder);

        var address = GetRandomElementFromListOfElements(webDriver.FindElements(AddressListHolder).ToList());

        address.Click();

        return new RecyclePage(context);
    }
    
    public void VerifyYourCollections() => VerifyPage(YourCollections, "Your collections");

    public static T GetRandomElementFromListOfElements<T>(List<T> elements)
    {
        var randomNumber = new Random().Next(0, elements.Count);

        return elements[randomNumber];
    }
}
