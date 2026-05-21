namespace hello_csharp;

internal static class MoodExtensions
{
    public static string Describe(this Mood mood) => mood switch
    {
        Mood.Bright => "Bright",
        Mood.Calm => "Calm",
        Mood.Curious => "Curious",
        Mood.Chaotic => "Chaotic",
        Mood.Tired => "Tired",
        Mood.Mysterious => "Mysterious",
        _ => "Unclassifiable"
    };
}
