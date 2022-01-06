// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        
        var phoneNumber = new PhoneNumberS();
        var origin = phoneNumber switch
        {
            { Number: 112 } => "Emergency",
            { Code: 44 } => "UK",
            { } => "Indeterminate"
        };

        var person = new Person();
        var personsOrigin = person switch
        {
            { Name: "Dimitri" } => "Russian",
            { PhoneNumber: { Code: 47 } } => "Sweden",
            { Name: var name } => $"No idea where {name} lives"
        };

        var error = person switch
        {
            null => "Object missing",
            { PhoneNumber: null } => "Phone number is missing entirely",
            { PhoneNumber: { Number: 0 } } => "Actual number is missing",
            { PhoneNumber: { Code: var code } } when code < 0 => "Code is wrong!!",
            { } => null

        };

        var shape = new Shape();
        var type = shape switch
        {
            Rectangle((0, 0), 0, 0) => "Point at origin",
            Circle((0, 0), _) => "Circle at origin",
            Rectangle(_, var w, var h) when w == h => "square",
            Rectangle((var x, var y), var w, var h) =>
            $"A {w}X{h} rectangle at ({x},{y})",
            _ => "other shape"
        };


        var A = "";
        if (A is not null)
        {

        }
        var X = 1.0;
        if (X is < 2 and > 0)
        {
            Console.WriteLine("And condition");
        }

        if (X is < 2 or > 5)
        {
            Console.WriteLine("or condition");
        }

        int temperature = -2;
        var feel = temperature switch
        {
            < 0 => "Freezing",
            > 0 and < 20 => "Tolerable",
            > 20 => "Hot"
        };


    }
}

class Person
{
    public string Name;
    public PhoneNumber PhoneNumber;
}

class PhoneNumber
{
    public int Code, Number;
}
struct PhoneNumberS
{
    public int Code, Number;
}

class Point
{
    public int X;
    public int Y;

    public void Deconstruct (out int x, out int y)
    {
        x = X;
        y = Y;
    }
}

class Shape
{
    public Point Point { get; set; }
}

class Rectangle : Shape
{
    public int Height { get; set; }
    public int Width { get; set; }

    public void Deconstruct(out Point point, out int width, out int height)
    {
        point = this.Point;
        width = Width;
        height = Height;

    }
}

class Circle: Shape
{
    public decimal Radius;

    public void Deconstruct(out Point point, out decimal radius)
    {
        point = this.Point;
        radius = Radius;

    }

}


