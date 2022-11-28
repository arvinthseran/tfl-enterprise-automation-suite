namespace Redbridge.UITests.Tests.StepDefinitions;

[Binding, Scope(Tag = "beta")]
public class BetaSteps
{
    private readonly ScenarioContext _context;
    private BetaSummaryPage betaSummaryPage;

    public BetaSteps(ScenarioContext context) => _context = context;    
    

    [When(@"the user selects an address")]
    public void WhenTheUserSelectsAnAddress() => betaSummaryPage = new BetaHomePage(_context, new SearchAddressPage(_context, true)).SearchAddress();

    [Then(@"the user should see the address summary")]
    public void ThenTheUserShouldSeeTheAddressSummary() => betaSummaryPage.VerifyAddressDetails();

}
