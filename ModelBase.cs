namespace hello_csharp;

internal abstract class ModelBase
{
    public bool IsDirty { get; set; }

    public override string ToString()
    {
        return $"is dirty: {IsDirty}";
    }
}
