// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

class Program
{
    public static string Name;

    [ModuleInitializer]
    public static void Initializer()
    {
        Name = "Mike";
    }

    //Static constructor
    static Program()
    {
        Name += " García";
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
