namespace DemoProject;

class Program
{
    static void Main(string[] args)
    {
        Truck myTruck = new Truck("Ford", "F-150", 2010, 3.0f, 182f);
        Console.WriteLine(myTruck);
        Console.WriteLine(myTruck.BedLength);
        Car myCar = new Car("Mitsubishi", "GTO", 1991, 3.0f, 210f);
        Console.WriteLine(myCar);
        Console.WriteLine(myCar.TrunkSize);

        List<Vehicle> vehicles = new List<Vehicle>() {
            myTruck,
            myCar
        };

        foreach (Vehicle vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }
        Console.WriteLine("Program end...");
    }
}
public abstract class Vehicle
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
public abstract class RoadVehicle : Vehicle
{
    public RoadVehicle(string manufacturer, string model, int year, float engineSize) : base(manufacturer, model, year)
    {
        this.EngineSize = engineSize;
    }
    public float EngineSize { get; set; }
}
public class Car : RoadVehicle
{
    public Car(string manufacturer, string model, int year, float engineSize, float trunkSize) : base(manufacturer, model, year, engineSize)
    {
        this.TrunkSize = trunkSize;
    }
    public float TrunkSize { get; set; }
    public override string ToString()
    {
        return base.ToString() + $" It has a {this.EngineSize}L engine and a {this.TrunkSize} cubic cm trunk.";
    }
}
public class Truck : RoadVehicle
{
    public Truck(string manufacturer, string model, int year, float engineSize, float bedLength) : base(manufacturer, model, year, engineSize)
    {
        this.BedLength = bedLength;
    }
    public float BedLength { get; set; }

    public override string ToString()
    {
        return base.ToString() + $" It has a {this.EngineSize}L engine and a {this.BedLength}cm bed.";
    }
}