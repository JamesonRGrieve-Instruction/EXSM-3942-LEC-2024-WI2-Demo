namespace DemoProject;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        // We cannot assign to derived properties as they are read-only (unless a setter is implemented).
        //person.FullName = "Test McTest";
        Console.WriteLine($"Person: {person.FirstName} {person.MiddleName} {person.LastName}");
        Console.WriteLine($"Full Name: {person.FullName}");
        Console.WriteLine(person.SingASong());
        Console.WriteLine("Program end...");
    }
}
public class Person
{
    public Person()
    {
        this.FirstName = "John";
        this.MiddleName = "Test";
        this.LastName = "Doe";
    }
    public Person(string firstName, string middleName, string lastName)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
    }
    public string? FirstName;
    private string? _middleName;
    public string? MiddleName
    {
        get
        {
            return _middleName;
        }
        set
        {
            _middleName = value;
        }
    }
    public string? LastName
    {
        get; set;
    }
    public string FullName
    {
        get
        {
            return $"{this.FirstName} {this.MiddleName} {this.LastName}";
        }
    }
    public string SingASong()
    {
        return $"Happy Birthday to you, Happy Birthday to you, Happy Birthday dear {this.FirstName}... Happy Birthday to you.";
    }
}
