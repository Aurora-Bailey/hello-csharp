namespace hello_csharp;

internal interface IUserDialogue
{
    Task<string> AskAsync(string prompt, CancellationToken cancellationToken = default);
    void Say(string message);
    void SayQuietly(string message);
}

internal sealed class ConsoleDialogue : IUserDialogue
{
    public Task<string> AskAsync(string prompt, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Console.Write(prompt);
        var answer = Console.ReadLine();

        return Task.FromResult(answer ?? string.Empty);
    }

    public void Say(string message)
    {
        Console.WriteLine(message);
    }

    public void SayQuietly(string message)
    {
        var previousColor = Console.ForegroundColor;

        try
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
        }
        finally
        {
            Console.ForegroundColor = previousColor;
        }
    }
}
