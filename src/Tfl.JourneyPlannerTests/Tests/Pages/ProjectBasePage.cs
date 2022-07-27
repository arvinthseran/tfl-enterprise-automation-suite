
namespace Tfl.JourneyPlannerTests.Tests.Pages;

public abstract class ProjectBasePage : BasePage
{
    private static By TflHomeLink => By.CssSelector(".tfl-name");

    public ProjectBasePage(ScenarioContext context) : base(context)
    {
    }

    public PlanAJourneyPage GoToPlanAJourneyPage()
    {
        driver.Click(TflHomeLink);
        return new(context);
    }
}
