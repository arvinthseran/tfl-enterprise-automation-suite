namespace Redbridge.UITests.Tests.StepDefinitions;

[Binding, Scope(Tag = "beta")]
public class BetaSteps
{
    private readonly ScenarioContext _context;
    private BetaSummaryPage betaSummaryPage;

    public BetaSteps(ScenarioContext context) => _context = context;    
    

    [When(@"the user selects an address")]
    public void WhenTheUserSelectsAnAddress() => betaSummaryPage = GetBetaHomePage().SearchValidAddress();

    [When(@"the user can not locate invalid postcode")]
    public void WhenTheUserCanNotLocateInvalidPostcode() => GetBetaHomePage().SearchInValidAddress();

    [When(@"the user can not locate error postcode")]
    public void WhenTheUserCanNotLocateErrorPostcode() => GetBetaHomePage().SearchErrorAddress();

    [Then(@"the user should see the address summary")]
    public void ThenTheUserShouldSeeTheAddressSummary() => betaSummaryPage.VerifyAddressDetails();

    private BetaHomePage GetBetaHomePage() => new(_context, new SearchAddressPage(_context, true));

}
