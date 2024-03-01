namespace DemoProject;

class Program
{
    static void Main(string[] args)
    {
        Pen pen = new Pen("Bic", "Blue");
        pen.Write(100);
        pen.Write(42);
        pen.Write(200);
        Console.WriteLine($"The pen has ${pen.InkLevel}% ink remaining.");
    }
}
public class Pen
{
    public Pen(string brand, string colour)
    {
        this.Brand = brand;
        this.Colour = colour;
        this.InkLevel = 100f;
    }
    public string Brand { get; set; }
    public string Colour { get; set; }
    private float _inkLevel;
    public float InkLevel
    {
        get
        {
            return _inkLevel;
        }
        private set
        {
            if (value < 0)
            {
                throw new Exception("InkLevel cannot be set to a negative value.");
            }
            this._inkLevel = value;
        }
    }

    public void Write(int characters)
    {
        try
        {
            InkLevel -= characters * 0.5f;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"ERROR: {exception.Message}");
        }
    }
}
