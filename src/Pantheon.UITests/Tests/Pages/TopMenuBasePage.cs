using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using UI.Framework.Support;

namespace Pantheon.UITests.Tests.Pages;

public abstract class TopMenuBasePage : BasePage
{
    protected static By TopMenus => By.CssSelector(".top-menu .menu-item-has-children");

    protected static By SubMenus => By.CssSelector(".sub-menu .menu-item a");

    protected override By PageHeader => By.CssSelector(".site-title");

    protected override string PageTitle => "Pantheon";

    public TopMenuBasePage(ScenarioContext context, bool verifyPage = true) : base(context, verifyPage)
    {

    }

    public void VerifySubMenu(string menu)
    {
        var expectedSubMenuPageTitle = MenuHierarchy.GetValueOrDefault(menu);

        IWebElement menuElement()
        {
            var topMenu = webDriver.FindElements(TopMenus);

            return topMenu.Single(x => x.Text.StartsWith(menu, StringComparison.OrdinalIgnoreCase));
        }

        menuElement().Click();

        var subMenuElements = menuElement().FindElements(SubMenus).Select(x => x.Text).ToList();

        foreach (var item in subMenuElements)
        {
            menuElement().Click();

            menuElement().FindElements(SubMenus).Single(x => x.Text == item).Click();

            string expectedPageTitle = (expectedSubMenuPageTitle is not null && expectedSubMenuPageTitle.ContainsKey(item)) ? expectedSubMenuPageTitle[item] : item;

            _ = new DynamicPage(context, By.CssSelector(".entry-header, .entry-title"), expectedPageTitle);
        }
    }


    private static Dictionary<string, Dictionary<string, string>> MenuHierarchy => new()
    {
        {"About", new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase) {{ "Our Services", "Investment" },{ "Diversity & Inclusion", "Diversity and Inclusion" }}}
    };

}
