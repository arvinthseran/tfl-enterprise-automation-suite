using Pantheon.UITests.Tests.Pages;

namespace Pantheon.UITests.Tests.StepDefinitions;

[Binding]
public class Steps
{
    private readonly ScenarioContext _context;
    public Steps(ScenarioContext context) => _context = context;

    [Then(@"the sub-links under (About) menu should be working")]
    public void ThenTheSub_LinksUnderAboutMenuShouldBeWorking(string menu) => new LandingPage(_context).VerifySubMenu(menu);
}
