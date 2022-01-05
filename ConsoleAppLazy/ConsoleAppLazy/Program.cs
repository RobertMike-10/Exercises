

// See https://aka.ms/new-console-template for more information
using System.Linq;

class Program
{
    static void Main()
    {
        // The lazy initializer is created here. LargeObject is not created until the
        // ThreadProc method executes.
        lazyLargeObject = new Lazy<LargeObject>(InitLargeObject);

        // The following lines show how to use other constructors to achieve exactly the
        // same result as the previous line:
        //lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, true);
        //lazyLargeObject = new Lazy<LargeObject>(InitLargeObject,
        //                               LazyThreadSafetyMode.ExecutionAndPublication);

        Console.WriteLine(
            "\r\nLargeObject is not created until you access the Value property of the lazy" +
            "\r\ninitializer. Press Enter to create LargeObject.");
        Console.ReadLine();

        // Create and start 3 threads, each of which uses LargeObject.
        Thread[] threads = new Thread[3];
        for (int i = 0; i < 3; i++)
        {
            threads[i] = new Thread(ThreadProc);
            threads[i].Start();
        }

        // Wait for all 3 threads to finish.
        foreach (Thread t in threads)
        {
            t.Join();
        }

        Console.WriteLine("\r\nPress Enter to end the program");
        Console.ReadLine();



        var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        //the element 6, third position from the end
        items[^2] = 33;
        Console.WriteLine(String.Join(",", items));
        //range from second to five position
        var newArray = items[1..4];
        Console.WriteLine(String.Join(",", newArray));
        //range from first to the second from the end
        var newItems = items[0..^1];
        Console.WriteLine(String.Join(",", newItems));

        var newItems2 = items[4..2];

        Index i1 = 0, i2 = 4;
        Range range = i1..i2;
        var newArray2 = items[range];
        Console.WriteLine(String.Join(",", newArray2));

        Range range2 = i2..;
        var newArray3 = items[range2];
        Console.WriteLine(String.Join(",", newArray3));

        Range range3 = ..i2;
        var newArray4 = items[range3];
        Console.WriteLine(String.Join(",", newArray4));

        var person = new Person("Mike", "García");
        var name = person[0];
        var lastname = person[1];

    }

    public class Person
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Person(string first, string last)
        {
        FirstName = first;
        LastName = last;
        }
        public string this[int i]
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
                        Name = key;
                        break;
                    case "address":
                        Address = key;
                        break;
                    case "phone":
                        PhoneNumber = key;
                        break;
                };
            }

        }
    }

   static Lazy<LargeObject> lazyLargeObject = null;

    static LargeObject InitLargeObject()
    {
        LargeObject large = new LargeObject(Thread.CurrentThread.ManagedThreadId);
        // Perform additional initialization here.
        return large;
    }

    static void ThreadProc(object state)
{
    LargeObject large = lazyLargeObject.Value;

    // IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the
    //            object after creation. You must lock the object before accessing it,
    //            unless the type is thread safe. (LargeObject is not thread safe.)
    lock (large)
    {
        large.Data[0] = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("Initialized by thread {0}; last used by thread {1}.",
            large.InitializedBy, large.Data[0]);
    }
}

}
class LargeObject
{
    public int InitializedBy { get { return initBy; } }

    int initBy = 0;
    public LargeObject(int initializedBy)
    {
        initBy = initializedBy;
        Console.WriteLine("LargeObject was created on thread id {0}.", initBy);
    }

    public long[] Data = new long[100000000];
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }

    public Person(string firstname, string lastname, string? middlename) => (FirstName, LastName, MiddleName) = (firstname, lastname, middlename);

    public String FullName => $"{FirstName} {MiddleName?[0]} {LastName}";
   
}