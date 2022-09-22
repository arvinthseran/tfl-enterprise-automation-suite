namespace UI.Framework.Support;

public class DynamicBasePage : BasePage
{
    private readonly By _pageheader;
    private readonly string _pageTitle;

    public DynamicBasePage(ScenarioContext context, By pageheader, string pagetitle) : base(context, false)
    {
        _pageheader = pageheader;
        _pageTitle = pagetitle;

        VerifyPage();
    }

    protected override By PageHeader => _pageheader;

    protected override string PageTitle => _pageTitle;
}
