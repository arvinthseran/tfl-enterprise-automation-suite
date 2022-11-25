using Redbridge.UITests.Tests.Pages;

namespace Redbridge.UITests.Tests.StepDefinitions;

[Binding]
public class Steps
{
    private readonly ScenarioContext _context;
    private BinsPage binsPage;
    private RecyclePage recyclePage;

    public Steps(ScenarioContext context) => _context = context;

    [Given(@"the user navigates to check your bin days page")]
    public void GivenTheUserNavigatesToCheckYourBinDaysPage() => binsPage = new AccessibilityPage(_context).GoToHomePage().GoToBins();

    [When(@"the user selects an address")]
    public void WhenTheUserSelectsAnAddress() => recyclePage = binsPage.GoToRecyclePage().EnterAddress();

    [Then(@"the user should see the bin collection days")]
    public void ThenTheUserShouldSeeTheBinCollectionDays() => recyclePage.VerifyYourCollections();
}
