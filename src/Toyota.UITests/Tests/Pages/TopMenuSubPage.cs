namespace Toyota.UITests.Tests.Pages;

public class TopMenuSubPage : ITopMenuPage
{
    public By NewVehicleMenu() => By.CssSelector("[data-gt-label='level1:New Vehicles']");

}
