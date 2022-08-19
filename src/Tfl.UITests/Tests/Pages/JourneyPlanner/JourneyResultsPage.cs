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

    public string GetFieldValidationErrors() => enterpriseWebdriver.GetText(FieldValidationErros);

    public string GetJourneyResults() => enterpriseWebdriver.GetText(JourneyResults);

    public string GetDisambiguationMessage() => enterpriseWebdriver.GetText(DisambiguationMessage);

    public bool IsDisambiguationMessageDisplayed() => enterpriseWebdriver.TryToFindNotVisibleElements(DisambiguationMessage).Count != 0;

    public JourneyResultsPage EditJourney()
    {
        enterpriseWebdriver.Click(EditJourneySelector);
        SelectTomorrow();
        return GoToJourneyResultsPage();
    }
}
