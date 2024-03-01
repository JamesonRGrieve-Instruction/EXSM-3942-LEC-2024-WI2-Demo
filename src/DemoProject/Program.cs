namespace DemoProject;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        people.Add(new Student("Tom", "Bob", "Smith", 3));
        // Forcing a Person into a Student (IE Line 16) will throw an Exception.
        //people.Add(new Person("Joe", "Billy", "Smith"));

        // We cannot assign to derived properties as they are read-only (unless a setter is implemented).
        //person.FullName = "Test McTest";
        foreach (Person person in people)
        {
            Console.WriteLine($"Person: {person.FirstName} {person.MiddleName} {person.LastName} of grade {((Student)person).Grade}.");
            Console.WriteLine($"Full Name: {person.FullName}");
            Console.WriteLine(person.SingASong());
        }
        Console.WriteLine("Program end...");
    }
}
public class Person
{
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
    // override means we are overriding the parent/super class's definition. Said definition must be flagged as abstract or virtual (or another override).
    // abstract means the declaration has no body and MUST be overridden by child classes (similar to what we learned in JavaScript).
    // virtual is a hybrid of the two, meaning it functions normally but CAN still be overridden.
    public virtual string SingASong()
    {
        return $"Happy Birthday to you, Happy Birthday to you, Happy Birthday dear {this.FirstName}... Happy Birthday to you.";
    }
}

public class Student : Person
{
    public Student(string firstName, string middleName, string lastName, int grade) : base(firstName, middleName, lastName)
    {
        this.Grade = grade;
    }
    public int Grade { get; set; }
    public override string SingASong()
    {
        return "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z... Now I know my ABC's.";
    }
}