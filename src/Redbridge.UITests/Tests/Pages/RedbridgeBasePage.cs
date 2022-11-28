using Redbridge.UITests.Support;

namespace Redbridge.UITests.Tests.Pages;

public abstract class RedbridgeBasePage : BasePage
{
    protected TestDataHelper testDataHelper;

    public RedbridgeBasePage(ScenarioContext context, bool verifyPage = true) : base(context, verifyPage)
    {
        testDataHelper = context.Get<TestDataHelper>();
    }
}
