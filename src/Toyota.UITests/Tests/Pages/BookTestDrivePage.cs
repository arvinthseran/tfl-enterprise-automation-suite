using System;

namespace Toyota.UITests.Tests.Pages;

public class BookTestDrivePage : ProjectBasePage
{
    public BookTestDrivePage(ScenarioContext context, ITopMenuPage topMenuPage) : base(context, false)
    {
        base.topMenuPage = topMenuPage;
        SwitchFrameAndAction(() => VerifyPage());
    }

    protected override By PageHeader => By.CssSelector("#test_drive");

    protected override string PageTitle => "Book a Test Drive";

    private static By SelectedCar => By.CssSelector("#selected_car");

    private static By Iframe => By.CssSelector("iframe[title='Book a Test Drive']");

    public void VerifySelectedCar(string expected) => SwitchFrameAndAction(() => VerifyPage(SelectedCar, expected));

    public void SwitchToFrame() => SwitchToFrame(Iframe);

    public void SwitchToFrame(By by) => webDriver.SwitchTo().Frame(webDriver.FindElement(by));

    public void SwitchToDefaultContent() => webDriver.SwitchTo().DefaultContent();

    public T SwitchFrameAndAction<T>(Func<T> func)
    {
        SwitchToFrame();
        var result = func.Invoke();
        SwitchToDefaultContent();
        return result;
    }

    public void SwitchFrameAndAction(Action action)
    {
        SwitchToFrame();
        action.Invoke();
        SwitchToDefaultContent();
    }
}
