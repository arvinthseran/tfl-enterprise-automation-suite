namespace Redbridge.UITests.Tests.Pages;

public class TestDataHelper
{
    public TestDataHelper()
    {
        Postcode = GetRandomElementFromListOfElements(_postcode);
    }

    public string Postcode { get; private set; }

    public T GetRandomElementFromListOfElements<T>(List<T> elements)
    {
        var randomNumber = new Random().Next(0, elements.Count);

        return elements[randomNumber];
    }

    private static readonly List<string> _postcode = new() { "IG1 3DF", "IG1 3DE", "IG1 3DH" };
}
