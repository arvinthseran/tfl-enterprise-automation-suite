namespace Tfl.Framework.Support
{
    public static class StringExtension
    {
        public static bool CompareToIgnoreCase(this string strA, string strB) => string.Compare(strA.RemoveSpace(), strB, true) == 0;

        public static string RemoveSpace(this string s) => Regex.Replace(s, @"\s+", string.Empty);

    }
}
