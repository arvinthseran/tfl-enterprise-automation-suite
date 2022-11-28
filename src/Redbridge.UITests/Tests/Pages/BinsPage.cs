namespace Redbridge.UITests.Tests.Pages;

public class BinsPage : RedbridgeBasePage
{
    public BinsPage(ScenarioContext context) : base(context) 
    {

    }

    private static By RecycleRefuse => By.CssSelector("a[href*='RecycleRefuse']");

    protected override By PageHeader => By.CssSelector(".lbr-page-title");

    protected override string PageTitle => "Bins, waste and recycling";

    public RecyclePage GoToRecyclePage()
    {
        enterpriseWebdriver.Click(RecycleRefuse);

        return new RecyclePage(context, new SearchAddressPage(context, true));
    }
}