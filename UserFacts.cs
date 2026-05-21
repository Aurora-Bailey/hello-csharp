namespace hello_csharp;

internal static class UserFacts
{
    public static string ToFriendlyName(this AgeGroup ageGroup) => ageGroup switch
    {
        AgeGroup.TinyLegend => "tiny legend",
        AgeGroup.TeenStrategist => "teen strategist",
        AgeGroup.GrownHuman => "grown human",
        AgeGroup.SeasonedPro => "seasoned pro",
        AgeGroup.AncientWizard => "ancient wizard",
        _ => "unmapped mystery"
    };
}
