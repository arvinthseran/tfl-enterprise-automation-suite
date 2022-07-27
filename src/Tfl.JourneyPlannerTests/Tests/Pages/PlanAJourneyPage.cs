
namespace Tfl.JourneyPlannerTests.Tests.Pages;

public class PlanAJourneyPage : PlanAJourneyForm
{
    private static By InputFromError => By.CssSelector("#InputFrom-error");

    private static By InputToError => By.CssSelector("#InputTo-error");

    private static By ChangeDepartureTime => By.CssSelector(".change-departure-time");

    private static By RecentTab => By.CssSelector("#jp-recent-tab-home");

    private static By RecentJourneyItems => By.CssSelector(".journey-item");

    public PlanAJourneyPage(ScenarioContext context) : base(context)
    {
    }

    protected override By PageHeader => By.CssSelector("#hp-journey-planner > .content");

    protected override string PageTitle => "Plan a journey";

    public JourneyResultsPage UserPlansAJourney(string from, string to)
    {
        EnterJourney(from, to);
        return GoToJourneyResultsPage();
    }

    public JourneyResultsPage UserPlansAJourneyBasedOnArrival(string from, string to)
    {
        EnterJourney(from, to);
        driver.Click(ChangeDepartureTime);
        driver.Click(Arriving);
        SelectTomorrow();
        return GoToJourneyResultsPage();
    }

    public PlanAJourneyPage UserPlansAJourneyWithNoLocations()
    {
        driver.Click(PlanJourneyButton);
        return new(context);
    }

    public string GetInputFromError() => driver.GetText(InputFromError);

    public string GetInputToError() => driver.GetText(InputToError);

    private void EnterJourney(string from, string to)
    {
        driver.EnterText(JourneyFrom, from);
        driver.EnterText(JourneyTo, to);
    }

    public string GetReentJourneyItem()
    {
        driver.Click(RecentTab);
        return driver.GetText(RecentJourneyItems);
    }
}
