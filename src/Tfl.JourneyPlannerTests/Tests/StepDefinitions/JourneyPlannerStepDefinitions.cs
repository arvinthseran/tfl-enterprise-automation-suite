namespace Tfl.JourneyPlannerTests.StepDefinitions;

[Binding]
public sealed class JourneyPlannerStepDefinitions
{
    private readonly ScenarioContext _context;

    public JourneyPlannerStepDefinitions(ScenarioContext context) => _context = context;

    [Given(@"the user wants to travel from '([^']*)' to '([^']*)'")]
    public void GivenTheUserWantsToTravelFromTo(string from, string to)
    {
        new LandingPage(_context);
    }

    [When(@"the user plan a journey")]
    public void WhenTheUserPlanAJourney()
    {
        
    }

    [Then(@"the user should see valid journey results")]
    public void ThenTheUserShouldSeeValidJourneyResults()
    {
        
    }

}