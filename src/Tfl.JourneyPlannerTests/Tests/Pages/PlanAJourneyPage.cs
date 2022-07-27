
namespace Tfl.JourneyPlannerTests.Tests.Pages;

public class PlanAJourneyPage : BasePage
{
    private static By JourneyFrom => By.CssSelector("#InputFrom");

    private static By JourneyTo => By.CssSelector("#InputTo");

    private static By PlanJourneyButton => By.CssSelector("#plan-journey-button");

    public PlanAJourneyPage(ScenarioContext context) : base(context)
    {
    }

    protected override By PageHeader => By.CssSelector("#hp-journey-planner > .content");

    protected override string PageTitle => "Plan a journey";

    public JourneyResultsPage UserPlansAJourney(string from, string to)
    {
        driver.EnterText(JourneyFrom, from);
        driver.EnterText(JourneyTo, to);
        driver.Click(PlanJourneyButton);
        return new(context);
    }
}
