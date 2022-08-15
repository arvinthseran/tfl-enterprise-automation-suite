namespace Toyota.UITests.Tests.Pages;

public class BookTestDrivePage : ProjectBasePage
{
    public BookTestDrivePage(ScenarioContext context, ITopMenuPage topMenuPage) : base(context, false)
    {
        base.topMenuPage = topMenuPage;
        driver.GetWebDriver().SwitchTo().Frame(driver.GetWebDriver().FindElement(By.CssSelector("iframe")));
        VerifyPage();
        driver.GetWebDriver().SwitchTo().DefaultContent();
    }

    protected override By PageHeader => By.CssSelector("#test_drive");

    protected override string PageTitle => "Book a Test Drive";

    private static By SelectedCar => By.CssSelector("#selected_car");

    public string GetSelectedCar() => driver.GetText(SelectedCar);

}
