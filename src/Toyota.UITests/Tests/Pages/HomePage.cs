using OpenQA.Selenium.Interactions;
using System.Linq;
using System.Xml.Linq;

namespace Toyota.UITests.Tests.Pages;


public class HomePage : ProjectBasePage
{
    public HomePage(ScenarioContext context, ITopMenuPage topMenuPage) : base(context)
    {
        base.topMenuPage = topMenuPage;
    }

    protected override By PageHeader => By.CssSelector("[data-gt-componentgroup='homepage']");

    protected override string PageTitle => "Welcome to Toyota";

    private static By NewVehicleMenu => By.CssSelector(".firstlevel");

    public AygoXHomePage GoToAygoXHomePage()
    {
        driver.FindElement(topMenuPage.NewVehicleMenu()).Click();

        driver.FindElement(NewVehicleMenu).Click();

        driver.GoToUrl($"{projectConfig.BaseUrl}/new-cars/aygo-x");

        return new AygoXHomePage(context, topMenuPage);
    }
}
