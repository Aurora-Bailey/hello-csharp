namespace hello_csharp;

internal static class Prompts
{
    private static readonly Dictionary<string, Mood> MoodAliases = new(StringComparer.OrdinalIgnoreCase)
    {
        ["bright"] = Mood.Bright,
        ["happy"] = Mood.Bright,
        ["calm"] = Mood.Calm,
        ["curious"] = Mood.Curious,
        ["nosy"] = Mood.Curious,
        ["chaotic"] = Mood.Chaotic,
        ["tired"] = Mood.Tired,
        ["sleepy"] = Mood.Tired,
        ["mysterious"] = Mood.Mysterious,
        ["weird"] = Mood.Mysterious
    };

    public static Prompt<string> Name { get; } = new("What should I call you? ", ReadName);
    public static Prompt<int> Age { get; } = new("How old are you? ", ReadAge);
    public static Prompt<Mood> MoodChoice { get; } = new("Pick a mood: bright, calm, curious, chaotic, tired, mysterious: ", ReadMood);
    public static Prompt<string> Hobby { get; } = new("What hobby is currently pretending to be your personality? ", ReadHobby);
    public static Prompt<int> FavoriteNumber { get; } = new("Favorite whole number between 1 and 100? ", ReadFavoriteNumber);
    public static Prompt<string> City { get; } = new("What city are you claiming today? ", ReadCity);
    public static Prompt<bool> BonusRoast { get; } = new("Do you want one bonus witty comment? yes/no: ", ReadYesNo);

    private static bool ReadName(string input, out string value, out string? error)
    {
        value = NormalizeText(input);

        if (value.Length >= 2)
        {
            error = null;
            return true;
        }

        error = "Give me at least two letters. I need enough material to be charming.";
        return false;
    }

    private static bool ReadAge(string input, out int value, out string? error)
    {
        if (int.TryParse(input, out value) && value is >= 1 and <= 130)
        {
            error = null;
            return true;
        }

        error = "Use a whole-number age from 1 to 130.";
        return false;
    }

    private static bool ReadMood(string input, out Mood value, out string? error)
    {
        if (MoodAliases.TryGetValue(input.Trim(), out value))
        {
            error = null;
            return true;
        }

        value = default;
        error = "That mood is too avant-garde for this tiny app.";
        return false;
    }

    private static bool ReadHobby(string input, out string value, out string? error)
    {
        value = NormalizeText(input);

        if (value.Length > 0)
        {
            error = null;
            return true;
        }

        error = "Pick something. Even 'staring into the fridge' counts.";
        return false;
    }

    private static bool ReadFavoriteNumber(string input, out int value, out string? error)
    {
        if (int.TryParse(input, out value) && value is >= 1 and <= 100)
        {
            error = null;
            return true;
        }

        error = "Use a whole number from 1 to 100.";
        return false;
    }

    private static bool ReadCity(string input, out string value, out string? error)
    {
        value = NormalizeText(input);

        if (value.Length > 0)
        {
            error = null;
            return true;
        }

        error = "A city, town, moon base, or approximate vibe is required.";
        return false;
    }

    private static bool ReadYesNo(string input, out bool value, out string? error)
    {
        switch (input.Trim().ToLowerInvariant())
        {
            case "y":
            case "yes":
                value = true;
                error = null;
                return true;
            case "n":
            case "no":
                value = false;
                error = null;
                return true;
            default:
                value = false;
                error = "Answer yes or no. This is not a philosophy exam.";
                return false;
        }
    }

    private static string NormalizeText(string input) => input.Trim();
}
