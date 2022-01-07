// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;


static class Program
{
    public static string Name;

    [ModuleInitializer]
    public static void Initializer()
    {
        Console.WriteLine($"Module Initialization");
        Name += " García";
    }

    //Static constructor
    static Program()
    {
        Console.WriteLine($"Class constructor");
        Name += "Mike";
    }

    static void Main(string[] args)
    {

        Console.WriteLine($"Hello, World! My creator is {Name}");

    }

}

record struct Person
{
    public string Name;
    public int Age;
    public Boolean Genre;

    public Person(string name, int age, bool genre)
    {
        Name = name;
        Age = age;
        Genre= genre;
    }
}
