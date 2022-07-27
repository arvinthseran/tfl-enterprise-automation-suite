
namespace Tfl.JourneyPlannerTests.Tests.Pages;

public class LandingPage : BasePage
{
    private static By AcceptCookies => By.CssSelector("#CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll");

    private static By SaveCookiesSettings => By.CssSelector("#cb-confirmedSettings .cb-button");

    public LandingPage(ScenarioContext context) : base(context, false)
    {
        driver.FindEnabledAndVisibleElement(AcceptCookies).Click();
        driver.FindEnabledAndVisibleElement(SaveCookiesSettings).Click();
        VerifyPage();
    }

    protected override By PageHeader => By.CssSelector("#hp-journey-planner > .content");

    protected override string PageTitle => "Plan a journey";
}
