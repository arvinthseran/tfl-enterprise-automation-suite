namespace Redbridge.UITests.Tests.Pages;

public class AccessibilityPage : RedbridgeBasePage
{
    public AccessibilityPage(ScenarioContext context) : base(context)
    {

    }
    private static By AgreeButton => By.CssSelector(".qc-cmp2-footer [mode=primary]");

    private static By OverlayOuter => By.CssSelector("#prefix-overlay-outer");

    private static By OverlayDismiss => By.CssSelector("#prefix-overlay-outer .prefix-overlay-action-dismiss");

    protected override By PageHeader => By.CssSelector(".qc-cmp2-consent-info");

    protected override string PageTitle => "We value your privacy";

    public HomePage GoToHomePage()
    {
        enterpriseWebdriver.Click(AgreeButton);

        if (webDriver.FindElements(OverlayOuter).Count > 0) enterpriseWebdriver.Click(OverlayDismiss);

        return new HomePage(context);

    }
}
