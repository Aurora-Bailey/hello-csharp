namespace hello_csharp;

internal class Student : ModelBase
{
    private string name;

    public Student(string name = "alice")
    {
        this.name = name;
    }

    public string Name
    {
        get => name;
        set
        {
            name = value;
            IsDirty = true;
        }
    }

    public override string ToString()
    {
        return $"name: {name} {base.ToString()}";
    }
}
