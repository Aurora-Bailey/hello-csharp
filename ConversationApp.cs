namespace hello_csharp;

internal sealed class ConversationApp(IUserDialogue dialogue, JokeBook jokeBook)
{
    private readonly List<User> users =
    [
        new()
        {
            Name = "Ada",
            Age = 36,
            Mood = Mood.Curious,
            Hobby = "debugging",
            FavoriteNumber = 17,
            City = "London"
        },
        new()
        {
            Name = "Linus",
            Age = 56,
            Mood = Mood.Chaotic,
            Hobby = "kernel gardening",
            FavoriteNumber = 42,
            City = "Helsinki"
        },
        new()
        {
            Name = "Grace",
            Age = 85,
            Mood = Mood.Calm,
            Hobby = "compiler archaeology",
            FavoriteNumber = 7,
            City = "New York"
        }
    ];

    public event EventHandler<User>? UserProfileCompleted;

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        dialogue.Say("hello.");
        dialogue.Say("I am going to ask a few questions, then pretend this counts as personality analysis.");
        dialogue.Say("");

        var user = await BuildUserAsync(cancellationToken);
        users.Add(user);
        UserProfileCompleted?.Invoke(this, user);

        dialogue.Say("");
        dialogue.Say("Here is what the tiny council has concluded:");

        foreach (var fact in BuildFactsFor(user))
        {
            dialogue.Say($"- {fact}");
        }

        dialogue.Say("");
        dialogue.Say("Witty comments, calibrated somewhere between friendly and suspicious:");

        foreach (var joke in jokeBook.For(user))
        {
            dialogue.Say($"- {joke.Text}");
        }

        if (await AskForBonusRoastAsync(cancellationToken))
        {
            dialogue.Say("");
            dialogue.Say(jokeBook.BonusFor(user));
        }

        dialogue.Say("");
        dialogue.Say($"bye, {user.Name}. Go be alarmingly {user.Mood.Describe().ToLowerInvariant()} somewhere else.");
    }

    private async Task<User> BuildUserAsync(CancellationToken cancellationToken)
    {
        var name = await dialogue.AskUntilValidAsync(Prompts.Name, cancellationToken);
        var age = await dialogue.AskUntilValidAsync(Prompts.Age, cancellationToken);
        var mood = await dialogue.AskUntilValidAsync(Prompts.MoodChoice, cancellationToken);
        var hobby = await dialogue.AskUntilValidAsync(Prompts.Hobby, cancellationToken);
        var favoriteNumber = await dialogue.AskUntilValidAsync(Prompts.FavoriteNumber, cancellationToken);
        var city = await dialogue.AskUntilValidAsync(Prompts.City, cancellationToken);

        var user = new User
        {
            Name = name,
            Age = age,
            Mood = mood,
            Hobby = hobby,
            FavoriteNumber = favoriteNumber,
            City = city
        };

        user.MarkComplete();

        return user;
    }

    private IEnumerable<string> BuildFactsFor(User user)
    {
        var (parity, isPrime, doubled) = NumberFacts.Inspect(user.FavoriteNumber);
        var neighbors = users
            .Where(other => other != user)
            .Where(other => Math.Abs(other.Age - user.Age) <= 10)
            .OrderBy(other => other.Age)
            .Select(other => other.Name)
            .ToList();
        var tags = user.GetSearchTags()
            .Distinct()
            .Order()
            .ToList();

        yield return $"{user.Name} from {user.City} is a {user.AgeGroup.ToFriendlyName()} aged {user.Age}.";
        yield return $"Mood report: {user.Mood.Describe()}.";
        yield return $"Profile complete: {user.IsComplete}. Search tags: {string.Join(", ", tags)}.";
        yield return $"Main hobby: {user.Hobby}. That is either a hobby or a cry for a calendar invite.";
        yield return $"Favorite number: {user.FavoriteNumber}, which is {parity}, doubled is {doubled}, and prime status is {isPrime}.";
        yield return neighbors.Count switch
        {
            0 => "No nearby age matches in the sample list. You stand alone, statistically dramatic.",
            1 => $"Closest age neighbor in the sample list: {neighbors[0]}.",
            _ => $"Nearby age neighbors in the sample list: {string.Join(", ", neighbors)}."
        };
    }

    private async Task<bool> AskForBonusRoastAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await dialogue.AskUntilValidAsync(Prompts.BonusRoast, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            dialogue.Say("The bonus roast escaped. Probably for legal reasons.");
            return false;
        }
    }
}
