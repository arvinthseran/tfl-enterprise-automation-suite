namespace Toyota.UITests.Tests.Pages;


public class AygoXHomePage : ProjectBasePage
{
    public AygoXHomePage(ScenarioContext context, ITopMenuPage topMenuPage) : base(context)
    {
        base.topMenuPage = topMenuPage;
    }

    protected override By PageHeader => By.CssSelector(".modelName");

    protected override string PageTitle => "Aygo X";

    private static By SelectManual => By.CssSelector("[data-gt-action='select-engine']");

    private static By SelectGrade => By.CssSelector("[data-gt-action='select-grade']");

    public AygoXPureHomePage GotoAygoXPureHomePage()
    {
        driver.Click(SelectManual);

        driver.Click(SelectGrade);

        return new AygoXPureHomePage(context, topMenuPage);
    }
}
