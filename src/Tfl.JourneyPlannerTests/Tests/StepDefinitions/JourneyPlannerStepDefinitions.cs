namespace Tfl.JourneyPlannerTests.StepDefinitions;

[Binding]
public sealed class JourneyPlannerStepDefinitions
{
    private readonly ScenarioContext _context;

    private string _journeyFrom,_journeyTo;

    private PlanAJourneyPage _planAJourneyPage;
    private JourneyResultsPage _journeyResultsPage;

    public JourneyPlannerStepDefinitions(ScenarioContext context) => _context = context;

    [Given(@"the user wants to travel from '([^']*)' to '([^']*)'")]
    public void GivenTheUserWantsToTravelFromTo(string from, string to)
    {
        _journeyFrom = from;

        _journeyTo = to;

        _planAJourneyPage =  new LandingPage(_context).GoToPlanAJourneyPage();
    }

    [When(@"the user plan a journey")]
    public void WhenTheUserPlanAJourney() => _journeyResultsPage  = _planAJourneyPage.UserPlansAJourney(_journeyFrom, _journeyTo);

    [Then(@"the user should see more than one matching location")]
    public void ThenTheUserShouldSeeMoreThanOneMatchingLocation() 
        => StringAssert.Contains("We found more than one location matching", _journeyResultsPage.GetDisambiguationMessage());

    [Then(@"the user should see valid journey results")]
    public void ThenTheUserShouldSeeValidJourneyResults() 
        => StringAssert.Contains("Fastest by public transport", _journeyResultsPage.GetJourneyResults());

    [Then(@"should not see more than one matching location")]
    public void ThenShouldNotSeeMoreThanOneMatchingLocation() => Assert.AreEqual(false, _journeyResultsPage.IsDisambiguationMessageDisplayed(), "more than one matching location found");

    [Then(@"the user shouldn't find matching journey results")]
    public void ThenTheUserShouldntFindMatchingJourneyResults() 
        => StringAssert.Contains("we can't find a journey matching your criteria", _journeyResultsPage.GetFieldValidationErrors());

}