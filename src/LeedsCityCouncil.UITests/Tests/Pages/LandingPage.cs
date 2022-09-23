using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Framework.Support;

namespace LeedsCityCouncil.UITests.Tests.Pages
{
    public class LandingPage : BasePage
    {
        public LandingPage(ScenarioContext context) : base(context)
        {

        }

        protected override By PageHeader => By.CssSelector(".hero__inner");

        protected override string PageTitle => "Welcome to Leeds";
    }
}
