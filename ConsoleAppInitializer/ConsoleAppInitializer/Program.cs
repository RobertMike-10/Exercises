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

        var me = new Person("Miguel", 36, true);
        var me2 = new Person("Miguel", 36, true);

        if (me == me2)
        {
            Console.WriteLine("Record struct is compared by value");
        }

        me2 = me;
        me2.Age = 48;
        Console.WriteLine(me.ToString());

        var cat = new Animal("Gato", "Black", 3);
        var cat2 = new Animal("Gato", "Black", 3);
        if (cat == cat2)
        {
            Console.WriteLine("struct needs aditional code to make comparations");
        }

        cat2 = cat;
        cat2.Color = "Yellow";
        Console.WriteLine(cat.ToString());

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

struct Animal
{    
    public string Name;
    public string Color;
    public int Age;
    public Animal (string name, string color, int age)
    {
        Name = name;
        Color = color;
        Age = age;
    }
  
    public override bool Equals(object obj)
    {
        if (!(obj is Animal)) return false;
        var other = (Animal)obj;
        return other.Name == Name && other.Color == Color && other.Age == Age ? true : false;
    }

    public override int GetHashCode() =>  throw new NotImplementedException();
    
    public override string ToString() => $"The {Color} {Name} has {Age} years old.";
    
}
