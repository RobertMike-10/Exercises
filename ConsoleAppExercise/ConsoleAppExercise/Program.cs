using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sp2 = SumAndProduct(2, 5);
            Console.WriteLine($"new sum = {sp2.sum}, product = {sp2.product}");
            var (sum, product) = SumAndProduct(3, 5);
            Console.WriteLine($"sum = {sum}, product = {product}");
            double s, p;
            (s, p) = SumAndProduct(1, 10);
            Console.WriteLine($"sum = {s}, product = {p}");
            var me = (name: "Miguel", age: 36);
            Console.WriteLine(me);
            Console.WriteLine($"My name is {me.name} and I am {me.age} years old");
            var snp = new Func<double, double, (double sum, double product)>((a, b) => (sum: a + b, product: a * b));
            var result = snp(1, 2);
            var (name, age) = me;

            var person = new Person("Miguel", "García",  "Saltillo", "Coahuila");

            // Deconstruct the person object.
            var (fName, lName, city, state) = person;

            Console.WriteLine($"Hello {fName} {lName} of {city}, {state}!");
            var(Name, _,cityName,stateName) = person;

            int[] moreNumbers = { 10, 20, 30 };
            ref int refToThirty = ref Find(moreNumbers, 30);
            refToThirty = 1000;
            Console.WriteLine(string.Join(",", moreNumbers));
            Find(moreNumbers, 10) = 1000;
            Console.WriteLine(string.Join(",",moreNumbers));

            int a = 1, b = 2;
            ref var minRef = ref Min(ref a, ref b);
            int minValue = Min(ref a, ref b);

        }

        static ref int Find(int[] numbers, int value)
        {            
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == value) return ref numbers[i];
            }
            throw new ArgumentException("Doesn't exists the value in the array");
        }            

        static ref int Min(ref int x, ref int y)
        {                      
            if (x < y) return ref x;
            return ref y;
        }

        static async ValueTask<long> GetDirSize(string dir)
        {
            if (!Directory.EnumerateFileSystemEntries(dir).Any())
                return 0;

            // Task<long> is return type so it still needs to be instantiated

            return await Task.Run(() => Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories)
              .Sum(f => new FileInfo(f).Length));
        }


        static (double sum, double product) SumAndProduct(double a, double b)
        {
            return (a + b, a * b);
        }

        static (double, double) SumAndProduct2(double a, double b)
        {
            return (a + b, a * b);
        }

        public static void Example(double a, double b, double c)
        {
            var CalculateDiscriminant = new Func<double, double, double, double>
                                                 ((aa, bb, cc) => bb * bb - 4 * aa * cc);
            double CalculateDiscriminant2(double aa, double bb, double cc)
             {
               return bb * bb - 4 * aa * cc;
             }
            double CalculateDiscriminant3(double aa, double bb, double cc) => bb * bb - 4 * aa * cc;
            double CalculateDiscriminant4() => b * b - 4 * a * c;
            double CalculateDiscriminant5()
            {
                return b* b - 4 * a * c;
            }

            var disc = CalculateDiscriminant(a, b, c);
            var disc2 = CalculateDiscriminant2(a, b, c);
            var disc3 = CalculateDiscriminant3(a, b, c);
            var disc4 = CalculateDiscriminant4();
            var disc5 = CalculateDiscriminant5();
        }
    }


    public class Person
    {
        public string FirstName { get; set; }       
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Person(string fname, string lname,
                      string cityName, string stateName)
        {
            FirstName = fname;           
            LastName = lname;
            City = cityName;
            State = stateName;
        }

        // Return the first and last name.
        public void Deconstruct(out string fname, out string lname)
        {
            fname = FirstName;
            lname = LastName;
        }

        public void Deconstruct(out string fname, out string lname,
                               out string city)
        {
            fname = FirstName;
            lname = LastName;
            city = City;           
        }

        public void Deconstruct(out string fname, out string lname,
                                out string city, out string state)
        {
            fname = FirstName;
            lname = LastName;
            city = City;
            state = State;
        }



    }


}
