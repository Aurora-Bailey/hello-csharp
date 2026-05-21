namespace hello_csharp;

internal delegate bool TryRead<T>(string input, out T value, out string? error);

internal sealed record Prompt<T>(string Question, TryRead<T> TryRead);

internal static class PromptExtensions
{
    public static async Task<T> AskUntilValidAsync<T>(
        this IUserDialogue dialogue,
        Prompt<T> prompt,
        CancellationToken cancellationToken = default)
    {
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var input = await dialogue.AskAsync(prompt.Question, cancellationToken);

            if (prompt.TryRead(input, out var value, out var error))
            {
                return value;
            }

            dialogue.Say(error ?? "That did not parse. Try again.");
        }
    }
}
