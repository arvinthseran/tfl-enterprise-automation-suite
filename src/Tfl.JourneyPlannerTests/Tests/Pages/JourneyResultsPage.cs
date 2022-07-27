﻿
namespace Tfl.JourneyPlannerTests.Tests.Pages;

public class JourneyResultsPage : BasePage
{
    private static By DisambiguationMessage => By.CssSelector(".info-message.disambiguation");

    private static By JourneyResults => By.CssSelector(".journey-results.publictransport");

    private static By FieldValidationErros => By.CssSelector(".field-validation-errors");

    public JourneyResultsPage(ScenarioContext context) : base(context)
    {

    }

    protected override By PageHeader => By.CssSelector(".headline-container");

    protected override string PageTitle => "Journey results";

    public string GetFieldValidationErrors() => driver.GetText(FieldValidationErros);

    public string GetJourneyResults() => driver.GetText(JourneyResults);

    public string GetDisambiguationMessage() => driver.GetText(DisambiguationMessage);

    public bool IsDisambiguationMessageDisplayed() => driver.TryToFindNotVisibleElements(DisambiguationMessage).Count != 0;
}
