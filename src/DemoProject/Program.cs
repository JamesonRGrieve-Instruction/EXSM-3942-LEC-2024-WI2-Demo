namespace DemoProject;

class Program
{
    static void Main(string[] args)
    {
        Vehicle myVehicle = new Vehicle("Ford", "F-150", 2010);
        Console.WriteLine(myVehicle.ToString());
        Console.WriteLine("Program end...");
    }
}
public class Vehicle
{
    public Vehicle(string manufacturer, string model, int year)
    {
        this.Manufacturer = manufacturer;
        this.Model = model;
        this.Year = year;
    }
    public string? Manufacturer
    {
        get; set;
    }
    public string? Model
    {
        get; set;
    }
    private int _year;
    public int Year
    {
        set
        {
            if (value < 1900 || value > DateTime.Now.Year + 1)
            {
                throw new ArgumentOutOfRangeException("value", "Value for Year cannot be less than 1900 or greater than the current year plus one.");
            }
            _year = value;
        }
        get
        {
            return _year;
        }
    }
    public override string ToString()
    {
        return $"A {this.Year} {this.Manufacturer} {this.Model}.";
    }
}
