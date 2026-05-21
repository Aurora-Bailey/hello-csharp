namespace hello_csharp;

internal class Program
{
    private static void Main(string[] args)
    {
        var f = new Foo();
        f.a = 3;
        var before = f.IncrimentBefore(1);
        var after = f.IncrimentAfter(1);
        var addHundred = f.AddHundred(1);
        var name = f.GetName();
        f.ChangeName("bob");
        var newName = f.GetName();

        var alice = new Student("bob");
        alice.Name = "alice";

        var bob = new Student("alice");
        bob.Name = "bob";

        Console.WriteLine($"Student: {alice}");

        Console.WriteLine($"Name before: {name} Name after: {newName}");
        Console.WriteLine($"before: {before} after: {after} hundred: {addHundred}");
        Console.WriteLine("Hello, World!");
    }
}
