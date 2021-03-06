// See https://aka.ms/new-console-template for more information


List<Employee> list = new List<Employee>();
list.Add(new Employee ("Mike",75000));
list.Add(new Employee ("Janet", 35000 ));
list.Add(new Employee("Ferdinand",  50000));
list.Add(new Employee("Liz", 75000 ));
list.Add(new Employee("Rick", 15000));
list.Add(new Employee("Esmeralda", 85000));
list.Add(new Employee("Lucy", 80000));

// Uses IComparable.CompareTo()
list.Sort();

// Uses Employee.ToString
foreach (var element in list)
{
    Console.WriteLine(element);
}

var empMax = list.Max();
var empMin = list.Min();

Console.WriteLine("Mayor:" + empMax?.ToString());
Console.WriteLine("Menor:" + empMin?.ToString());




class Employee : IComparable<Employee>
{
    public int Salary { get; set; }
    public string Name { get; set; } 
  
    public Employee(string name,int salary)
    {
        Salary = salary;
        Name = name;
    }
    public int CompareTo(Employee other)
    {
        if (other is null) return -1;
        // Alphabetic sort if salary is equal. [A to Z]
        if (this.Salary == other.Salary) return this.Name.CompareTo(other.Name);        
        // Default to salary sort. [Low to High]
        return this.Salary.CompareTo(other.Salary);
    }
    public override string ToString() => this.Salary.ToString() + "," + this.Name;
    
}
