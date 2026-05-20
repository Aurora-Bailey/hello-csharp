using System.Xml.Linq;

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

        Console.WriteLine($"Student: {alice}");

        Console.WriteLine($"Name before: {name} Name after: {newName}");
        Console.WriteLine($"before: {before} after: {after} hundred: {addHundred}");
        Console.WriteLine("Hello, World!");
    }
}

abstract class ModelBase { 
    public bool IsDirty { get; set; }

    public override string ToString(){
        return $"is dirty: {IsDirty.ToString()}";
    }
}

public class MyClass {
    private string something = "neio";

    public string FetchSomething(){
        return something;
    }

    public MyClass (){
        return;
    }
}

class Student: ModelBase {
    private string name;
    

    public string Name {
        get => name;
        set {
            name = value;
            IsDirty = true;
        } 
    }

    public Student(string name = "alice") => this.name = name;
    public override string ToString() => $"name: {name} {base.ToString()}";
    
}

class Foo {
    public int a = 1;
    private int b = 2;
    private int hundred = 100;

    private string name = "alice";
    
    

    public bool ChangeName(string newName) { 
        name = newName;
        return true;
    }

    public string GetName() {
        return name;
    }
     public int AddHundred(int value) {
        return value + hundred;
    }

    public int IncrimentBefore (int value) {
        return ++value;
    }

    public int IncrimentAfter(int value) {
        return value++;
    }
}
