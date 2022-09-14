using TechTalk.SpecFlow;

namespace Pantheon.UITests.Tests.StepDefinitions
{
    [Binding]
    public class Steps
    {
        public Steps(ScenarioContext context)
        {

        }

        [Then(@"the sub-links under About menu should be working")]
        public void ThenTheSub_LinksUnderAboutMenuShouldBeWorking()
        {
            throw new PendingStepException();
        }

    }
}
