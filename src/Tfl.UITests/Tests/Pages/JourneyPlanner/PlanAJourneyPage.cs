namespace Tfl.UITests.Tests.Pages.JourneyPlanner;

public class PlanAJourneyPage : PlanAJourneyForm
{
    private static By InputFromError => By.CssSelector("#InputFrom-error");

    private static By InputToError => By.CssSelector("#InputTo-error");

    private static By ChangeDepartureTime => By.CssSelector(".change-departure-time");

    private static By RecentTab => By.CssSelector("#jp-recent-tab-home");

    private static By RecentJourneyItems => By.CssSelector(".journey-item");

    private static By InputFromDropdown => By.CssSelector("#InputFrom-dropdown .stop-name");

    private static By InputToDropdown => By.CssSelector("#InputTo-dropdown .stop-name");

    public PlanAJourneyPage(ScenarioContext context) : base(context) { }

    protected override By PageHeader => By.CssSelector("#hp-journey-planner > .content");

    protected override string PageTitle => "Plan a journey";

    public JourneyResultsPage UserPlansAJourney(string from, string to)
    {
        EnterJourney(from, to);
        return GoToJourneyResultsPage();
    }

    public JourneyResultsPage UserPlansAJourneyFromSuggestions(string from, string to)
    {
        EnterJourneyInput(InputFrom, InputFromDropdown, from);

        EnterJourneyInput(InputTo, InputToDropdown, to);

        return GoToJourneyResultsPage();
    }

    public JourneyResultsPage UserPlansAJourneyBasedOnArrival(string from, string to)
    {
        EnterJourney(from, to);
        enterpriseWebdriver.Click(ChangeDepartureTime);
        enterpriseWebdriver.Click(Arriving);
        SelectTomorrow();
        return GoToJourneyResultsPage();
    }

    public PlanAJourneyPage UserPlansAJourneyWithNoLocations()
    {
        enterpriseWebdriver.Click(PlanJourneyButton);
        return new(context);
    }

    public string GetInputFromError() => enterpriseWebdriver.GetText(InputFromError);

    public string GetInputToError() => enterpriseWebdriver.GetText(InputToError);

    private void EnterJourney(string from, string to)
    {
        enterpriseWebdriver.EnterText(InputFrom, from);
        enterpriseWebdriver.EnterText(InputTo, to);
    }

    public bool IsRecentJourneyItemDisplayed()
    {
        enterpriseWebdriver.Click(RecentTab);
        return enterpriseWebdriver.TryToFindNotVisibleElements(RecentJourneyItems).Count >= 1;
    }

    private void EnterJourneyInput(By textbox, By dropdown, string text)
    {
        enterpriseWebdriver.EnterText(textbox, text, false);

        var element = enterpriseWebdriver.FindEnabledAndDisplayedElement(dropdown);

        new Actions(webDriver).MoveToElement(element).Click(element).Perform();
    }
}
