namespace Toyota.UITests.Tests.Pages;

public class AygoXPureHomePage : ProjectBasePage
{
    public AygoXPureHomePage(ScenarioContext context, ITopMenuPage topMenuPage): base(context)
    {
        base.topMenuPage = topMenuPage;
    }

    protected override By PageHeader => By.CssSelector(".cmp-carherograde__title");

    protected override string PageTitle => "Aygo X Pure";

    private static By BookTestDriveSelector => By.CssSelector("[href='/test-drive?model=ax']");

    public BookTestDrivePage BookTestDrive()
    {
        enterpriseWebdriver.Click(BookTestDriveSelector);

        return new BookTestDrivePage(context, topMenuPage);
    }
}
