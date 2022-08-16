using Toyota.UITests.Tests.Pages;

namespace Toyota.UITests.Tests.StepDefinitions
{
    [Binding]
    public class BookATestDriveSteps
    {
        private readonly ScenarioContext _context;

        private HomePage homePage;

        private AygoXHomePage aygoXHomePage;

        private BookTestDrivePage bookTestDrivePage; 

        public BookATestDriveSteps(ScenarioContext context) => _context = context;

        [Given(@"A user wants to book a test drive")]
        public void GivenAUserWantsToBookATestDrive()
        {
            new AcceptCookiesPage(_context).AcceptCookies();

            homePage = new HomePage(_context, new TopMenuSubPage());
        }

        [When(@"the user selects a car from new vehicle")]
        public void WhenTheUserSelectsACarFromNewVehicle() => aygoXHomePage = homePage.GoToAygoXHomePage();

        [Then(@"the user is taken to Book a test drive page")]
        public void ThenTheUserIsTakenToBookATestDrivePage() => bookTestDrivePage = aygoXHomePage.GotoAygoXPureHomePage().BookTestDrive();

        [Then(@"(.*) should be pre selected")]
        public void ThenAllNewAygoXShouldBePreSelected(string expected) => bookTestDrivePage.VerifySelectedCar(expected);
    }
}
