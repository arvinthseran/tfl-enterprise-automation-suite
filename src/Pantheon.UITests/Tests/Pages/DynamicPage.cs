using OpenQA.Selenium;

namespace Pantheon.UITests.Tests.Pages;

public class DynamicPage : TopMenuBasePage
{
    private readonly By _pageheader;
    private readonly string _pageTitle;

    public DynamicPage(ScenarioContext context, By pageheader, string pagetitle) : base(context, false)
    {
        _pageheader = pageheader;
        _pageTitle = pagetitle;

        VerifyPage();
    }

    protected override By PageHeader => _pageheader;

    protected override string PageTitle => _pageTitle;
}
