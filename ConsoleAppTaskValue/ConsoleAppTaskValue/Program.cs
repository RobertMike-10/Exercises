// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;

internal class Program
{

    class Monster
    {
        public String Name { get; set; }
        public double PowerAttack { get; set; }
        public double PowerDefense { get; set; }
      
        public Monster(string name, double attack, double defense)
        {
            Name = name;
            PowerAttack = attack;
            PowerDefense = defense;
        }
        public override string ToString()
        {
            return $"{Name} Attack:{PowerAttack} Defense:{PowerDefense}";
        }
    }
    struct Point
    {
        public double X, Y;
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }     
        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }

    struct MyPoint
    {
        public int x;
        public int y;
        public void SetXY(int i, int j)
        {
            x = i;
            y = j;
        }
        public void ShowXY()
        {
            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }

    // 'in' is effectively by-ref and read-only
    static double MeasureDistance(in Point p1, in Point p2)
    {       
        var dx = p1.X - p2.X;
        var dy = p1.Y - p2.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    static bool FigthMonsters(in Monster m1, in Monster m2)
    {        
        m1.PowerAttack = 1000;      
        if (m2.PowerDefense >= m1.PowerAttack)
            return true;
        else
            return false;       
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //Console.WriteLine(GetDirSize(@"c:\temp").Result);

        int a = default;
       
        int? b = default;
        Console.WriteLine(b);

        int? c = default(int);
        Console.WriteLine(c);

        var e = new[] { default, 33, default };
        Console.WriteLine(string.Join(",", e));

        if (a == default) Console.WriteLine("El valor es cero");
               
        var x = a > 0 ? default : 1.5;
        Console.WriteLine(x);

        Console.WriteLine(Result());

        var p1 = new Point(1, 1);
        var p2 = new Point(4, 5);
        var distance = MeasureDistance(p1, p2); 
        
        Console.WriteLine($"Distance between {p1} and {p2} is {distance}");


        var pikachu = new Monster("Pikachu",1500,2000);
        var charizad = new Monster("Charizard",3500, 2500);
        var result = FigthMonsters(charizad, pikachu);
        Console.WriteLine(result);
        Console.WriteLine(charizad.ToString());

        unsafe
        {
            int z = 10;
            int y = 20;
            int* ptr1 = &z;
            int* ptr2 = &y;
            Console.WriteLine((int)ptr1);
            Console.WriteLine((int)ptr2);
            Console.WriteLine(*ptr1);
            Console.WriteLine(*ptr2);
            int* sum = swap(&z, &y);
            Console.WriteLine(*sum);
            int[] iArray = new int[10];
            for (int count = 0; count < 10; count++)
            {
                iArray[count] = count * count;
            }

            Console.WriteLine("Array");
            fixed (int* ptr = iArray)            
               Display(ptr);

            MyPoint ms = new MyPoint();
            MyPoint* ms1 = &ms;
            ms1->SetXY(10, 20);
            ms1->ShowXY();
        }




        var arrayInt = new int[] { 1, 3, 4, 5, 6, 7, 8, 9 };
        var last1 = HeapAllocReverseArray(arrayInt);
        var last2 = UnsafeStackAllocReverse(arrayInt);
        var last3= SafeStackOrHeapAllocReverse(arrayInt);

        unsafe
        {
            // managed
            byte* ptr = stackalloc byte[100];
            Span<byte> memory = new Span<byte>(ptr, 100);

            // unmanaged
            IntPtr unmanagedPtr = Marshal.AllocHGlobal(123);
            Span<byte> unmanagedMemory = new Span<byte>(unmanagedPtr.ToPointer(), 123);
            Marshal.FreeHGlobal(unmanagedPtr);
        }

        // implicit cast
        char[] stuff = "hello".ToCharArray();
        Span<char> arrayMemory = stuff;

        // string is immutable so we can make a readonly span
        ReadOnlySpan<char> more = "Hello world!".AsSpan();

        Console.WriteLine($"Our span has {more.Length} elements");

        arrayMemory.Fill('x');
        Console.WriteLine(stuff);
        arrayMemory.Clear();
        Console.WriteLine(stuff);
    }


    public static unsafe int* swap(int* x, int* y)
    {
        int sum;
        sum = *x + *y;
        return &sum;  
    }

    public static unsafe void Display(int* pt)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(*(pt + i));
        }
    }

    //returns last element
    public static int HeapAllocReverseArray(int[] data)
    {
        // Heap-allocated array 
        int[] array = new int[data.Length];
        Array.Copy(data, array, data.Length);
        Array.Reverse(array);
        return array[0];
    }

    public static int UnsafeStackAllocReverse(int[] data)
    {
        unsafe
        {
            // We lose safety and bounds checks
            int* ptr = stackalloc int[data.Length];
            // No APIs available to copy and reverse
            for (int i = 0; i < data.Length; i++)
            {
                ptr[i] = data[data.Length - i - 1];
            }
            return ptr[0];
        }
    }

    public static int SafeStackOrHeapAllocReverse(int[] data)
    {
        // Chose an arbitrary small constant
        Span<int> span = data.Length < 128 ?
                    stackalloc int[data.Length] :
                    new int[data.Length];
        data.CopyTo(span);
        span.Reverse();
        return span[0];
    }

    static int Result()
    {
        return default;
    }

    static async ValueTask<long> GetDirSize(string dir)
    {
        if (!Directory.EnumerateFileSystemEntries(dir).Any())
            return 0;

        // Task<long> is return type so it still needs to be instantiated

        return await Task.Run(() => Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories)
          .Sum(f => new FileInfo(f).Length));
    }

}