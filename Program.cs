namespace hello_csharp;

internal static class Program
{
    private static async Task Main()
    {
        using var cancellation = new CancellationTokenSource();

        IUserDialogue dialogue = new ConsoleDialogue();
        var app = new ConversationApp(dialogue, new JokeBook());

        app.UserProfileCompleted += (_, user) =>
        {
            dialogue.SayQuietly($"profile captured at {user.CreatedAt:HH:mm}");
        };

        await app.RunAsync(cancellation.Token);
    }
}
