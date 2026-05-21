namespace hello_csharp;

internal abstract class ProfileBase
{
    public DateTime CreatedAt { get; } = DateTime.Now;
    public bool IsComplete { get; protected set; }

    public abstract IEnumerable<string> GetSearchTags();
}
