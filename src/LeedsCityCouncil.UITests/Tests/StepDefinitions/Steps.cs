using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LeedsCityCouncil.UITests.Tests.StepDefinitions
{
    public class Steps
    {
        private readonly ScenarioContext _context;
        
        public Steps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"the user navigates to check your bin days page")]
        public void GivenTheUserNavigatesToCheckYourBinDaysPage()
        {
            
        }

        [When(@"the user selects an address")]
        public void WhenTheUserSelectsAnAddress()
        {

        }

        [Then(@"the user should see the bin collection days")]
        public void ThenTheUserShouldSeeTheBinCollectionDays()
        {
            
        }



    }
}
