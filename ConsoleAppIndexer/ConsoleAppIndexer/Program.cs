// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var person = new Person("Mike", "García");
var name = person[0];
var lastname = person[1];
Console.WriteLine($" My name is {name} {lastname}");

var employee = new Employee("Esmeralda", "calle 123", "32323232");
var eName = employee["name"];
var phone = employee["phone"];
employee["name"] = "Beatriz";
Console.WriteLine($" My name is {employee["name"]} this is my phone {phone}");


class Person
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public Person (string first, string last)
    {
        FirstName = first;
        LastName = last;
    }

    public string this[int i ]
    {
        get { return i > 0 ? LastName : FirstName; }
        init
        {
            if (i > 0) LastName = value;
            else FirstName = value;
        }
    }
}

public class Employee
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    public Employee(string name, string address, string phone)
    {
        Name = name;
        Address = address;
        PhoneNumber = phone;
    }

    public string this[string key]
    {
        get
        {
            switch (key)
            {
                case "name":
                    return Name;
                case "address":
                    return Address;
                case "phone":
                    return PhoneNumber;
                default: return null;
            };
        }
        set
        {
            switch (key)
            {
                case "name":
                    Name = value;
                    break;
                case "address":
                    Address = value;
                    break;
                case "phone":
                    PhoneNumber = value;
                    break;
            };
        }

    }
}