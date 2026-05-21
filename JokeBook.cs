namespace hello_csharp;

internal sealed class JokeBook
{
    private readonly Dictionary<Mood, string> moodNeedles = new()
    {
        [Mood.Bright] = "That level of optimism should be bottled and sold to project managers.",
        [Mood.Calm] = "Suspiciously calm. Either enlightened or your notifications are off.",
        [Mood.Curious] = "Curious is good. It is how people find bugs and questionable fridge leftovers.",
        [Mood.Chaotic] = "Chaotic energy detected. Somewhere, a spreadsheet just developed anxiety.",
        [Mood.Tired] = "Tired, but still answering questions. Heroic or poor boundary management.",
        [Mood.Mysterious] = "Mysterious. Classic move from someone avoiding a follow-up question."
    };

    public IEnumerable<WittyRemark> For(User user)
    {
        yield return new WittyRemark(moodNeedles[user.Mood], JokeStrength.Gentle);

        yield return user.AgeGroup switch
        {
            AgeGroup.TinyLegend => new WittyRemark("You are young enough that your knees probably still trust you.", JokeStrength.Gentle),
            AgeGroup.TeenStrategist => new WittyRemark("Teen strategist era: enough confidence to argue, enough homework to resent clocks.", JokeStrength.Medium),
            AgeGroup.GrownHuman => new WittyRemark("Adult detected. You probably own at least one cable you are afraid to throw away.", JokeStrength.Medium),
            AgeGroup.SeasonedPro => new WittyRemark("Seasoned pro status. Your opinions now come with footnotes.", JokeStrength.Medium),
            AgeGroup.AncientWizard => new WittyRemark("Ancient wizard tier. You have seen technologies become cool twice.", JokeStrength.Spicy),
            _ => new WittyRemark("Time has failed to categorize you, which is honestly a brand.", JokeStrength.Gentle)
        };

        yield return user.Hobby.Length switch
        {
            < 5 => new WittyRemark($"'{user.Hobby}' is a compact hobby. Minimalist. Suspiciously efficient.", JokeStrength.Gentle),
            > 18 => new WittyRemark($"'{user.Hobby}' is a long hobby name. Very premium. Probably has a waitlist.", JokeStrength.Medium),
            _ => new WittyRemark($"'{user.Hobby}' sounds respectable, which makes it harder to roast. Annoying.", JokeStrength.Gentle)
        };
    }

    public string BonusFor(User user)
    {
        var mood = user.Mood.Describe().ToLowerInvariant();
        var article = "aeiou".Contains(mood[0]) ? "an" : "a";

        return $"{user.Name}, you have {article} {mood} vibe, a {user.FavoriteNumber}-based personality, and the confidence of someone who calls '{user.Hobby}' a plan.";
    }
}
