using Toyota.UITests.Support;

namespace Toyota.UITests.Tests.Pages;


public abstract class ProjectBasePage : BasePage
{
    protected ITopMenuPage topMenuPage;

    protected ProjectConfig projectConfig;

    public ProjectBasePage(ScenarioContext context, bool verifyPage = true) : base(context, verifyPage)
    {
        projectConfig = context.Get<ProjectConfig>();
    }

}
