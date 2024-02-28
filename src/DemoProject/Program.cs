namespace DemoProject;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        person.FirstName = "John";
        person.MiddleName = "Test";
        person.LastName = "Doe";
        Console.WriteLine($"Person: {person.FirstName} {person.MiddleName} {person.LastName}");
        Console.WriteLine("Program end...");
    }
}
public class Person
{
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

}
