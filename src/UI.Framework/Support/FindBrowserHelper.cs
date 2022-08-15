namespace UI.Framework.Support;

public static class FindBrowserHelper
{
    public static bool IsFirefox(this string browser) => browser.CompareToIgnoreCase("firefox") || browser.CompareToIgnoreCase("mozillafirefox");

    public static bool IsChrome(this string browser) => browser.CompareToIgnoreCase("chrome") || browser.CompareToIgnoreCase("googlechrome");
}