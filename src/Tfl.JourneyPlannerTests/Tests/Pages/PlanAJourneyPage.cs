
using OpenQA.Selenium.Interactions;

namespace Tfl.JourneyPlannerTests.Tests.Pages;

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
        driver.EnterText(InputFrom, from);
        driver.EnterText(InputTo, to);
    }

    public bool IsRecentJourneyItemDisplayed()
    {
        driver.Click(RecentTab);
        return driver.TryToFindNotVisibleElements(RecentJourneyItems).Count >= 1;
    }

    private void EnterJourneyInput(By textbox, By dropdown, string text)
    {
        driver.EnterText(textbox, text, false);

        var element = driver.FindEnabledAndDisplayedElement(dropdown);

        new Actions(driver.GetWebDriver()).MoveToElement(element).Click(element).Perform();
    }
}
