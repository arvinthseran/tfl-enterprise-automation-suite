namespace Tfl.UITests.Tests.Pages.JourneyPlanner;

public class JourneyResultsPage : PlanAJourneyForm
{
    private static By DisambiguationMessage => By.CssSelector(".info-message.disambiguation");

    private static By JourneyResults => By.CssSelector(".journey-results.publictransport");

    private static By FieldValidationErros => By.CssSelector(".field-validation-errors");

    private static By EditJourneySelector => By.CssSelector(".edit-journey");

    public JourneyResultsPage(ScenarioContext context) : base(context)
    {

    }

    protected override By PageHeader => By.CssSelector(".headline-container");

    protected override string PageTitle => "Journey results";

    public string GetFieldValidationErrors() => driver.GetText(FieldValidationErros);

    public string GetJourneyResults() => driver.GetText(JourneyResults);

    public string GetDisambiguationMessage() => driver.GetText(DisambiguationMessage);

    public bool IsDisambiguationMessageDisplayed() => driver.TryToFindNotVisibleElements(DisambiguationMessage).Count != 0;

    public JourneyResultsPage EditJourney()
    {
        driver.Click(EditJourneySelector);
        SelectTomorrow();
        return GoToJourneyResultsPage();
    }
}
