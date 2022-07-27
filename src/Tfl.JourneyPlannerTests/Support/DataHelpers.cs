namespace Tfl.JourneyPlannerTests.Support;

public record DataHelpers
{
    public (string from, string to) ValidJourney { get; init; } = ("West Sutton Rail Station", "North Greenwich Underground Station");

    public (string from, string to) InValidJourney { get; init; } = ("SM3 9YY", "SM3 8YY");

    public (string from, string to) MultipleLocation { get; init; } = ("Sutton", "North Greenwich");

    public (string from, string to) EmptyLocation { get; init; } = (String.Empty, String.Empty);
}
