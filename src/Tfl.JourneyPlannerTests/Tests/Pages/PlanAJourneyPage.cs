
namespace Tfl.JourneyPlannerTests.Tests.Pages;

public class PlanAJourneyPage : BasePage
{
    private static By JourneyFrom => By.CssSelector("#InputFrom");

    private static By JourneyTo => By.CssSelector("#InputTo");

    private static By PlanJourneyButton => By.CssSelector("#plan-journey-button");

    private static By InputFromError => By.CssSelector("#InputFrom-error");

    private static By InputToError => By.CssSelector("#InputTo-error");

    private static By ChangeDepartureTime => By.CssSelector(".change-departure-time");

    private static By Arriving => By.CssSelector("label[for='arriving']");

    private static By DateSelector => By.CssSelector("#Date");


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
        driver.SelectByText(DateSelector, "Tomorrow");
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

    private JourneyResultsPage GoToJourneyResultsPage()
    {
        driver.Click(PlanJourneyButton);
        return new(context);
    }
}
