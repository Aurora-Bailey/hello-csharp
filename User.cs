namespace hello_csharp;

internal sealed class User : ProfileBase
{
    public required string Name { get; init; }
    public required int Age { get; init; }
    public required Mood Mood { get; init; }
    public required string Hobby { get; init; }
    public required int FavoriteNumber { get; init; }
    public required string City { get; init; }

    public bool IsAdult => Age >= 18;

    public AgeGroup AgeGroup => Age switch
    {
        < 13 => AgeGroup.TinyLegend,
        < 20 => AgeGroup.TeenStrategist,
        < 45 => AgeGroup.GrownHuman,
        < 70 => AgeGroup.SeasonedPro,
        _ => AgeGroup.AncientWizard
    };

    public override IEnumerable<string> GetSearchTags()
    {
        yield return Name.ToLowerInvariant();
        yield return Mood.ToString().ToLowerInvariant();
        yield return Hobby.ToLowerInvariant();
        yield return City.ToLowerInvariant();

        if (IsAdult)
        {
            yield return "adult";
        }
    }

    public void MarkComplete()
    {
        IsComplete = true;
    }
}
