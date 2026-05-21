namespace hello_csharp;

internal class Foo
{
    public int a = 1;
    private int hundred = 100;

    private string name = "alice";

    public bool ChangeName(string newName)
    {
        name = newName;
        return true;
    }

    public string GetName()
    {
        return name;
    }

    public int AddHundred(int value)
    {
        return value + hundred;
    }

    public int IncrimentBefore(int value)
    {
        return ++value;
    }

    public int IncrimentAfter(int value)
    {
        return value++;
    }
}
