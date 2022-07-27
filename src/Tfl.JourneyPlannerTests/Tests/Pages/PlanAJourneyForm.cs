
namespace Tfl.JourneyPlannerTests.Tests.Pages;

public abstract class PlanAJourneyForm : ProjectBasePage
{
    protected static By InputFrom => By.CssSelector("#InputFrom");

    protected static By InputTo => By.CssSelector("#InputTo");

    protected static By PlanJourneyButton => By.CssSelector("#plan-journey-button");

    protected static By Arriving => By.CssSelector("label[for='arriving']");

    protected static By DateSelector => By.CssSelector("#Date");


    public PlanAJourneyForm(ScenarioContext context) : base(context)
    {
    }

    protected void SelectTomorrow() => driver.SelectByText(DateSelector, "Tomorrow");

    protected JourneyResultsPage GoToJourneyResultsPage()
    {
        driver.Click(PlanJourneyButton);
        return new(context);
    }
}
