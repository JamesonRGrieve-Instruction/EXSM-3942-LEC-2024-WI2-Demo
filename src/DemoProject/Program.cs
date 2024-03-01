namespace DemoProject;

class Program
{
    static void Main(string[] args)
    {
        Pen pen = new Pen("Bic", "Blue", 80f);
        pen.Write(100);
        pen.Write(42);
        pen.Write(200);
        Console.WriteLine($"The pen has {pen.InkLevel:0.00}mL of ink remaining, {pen.CalcRemainingInkPercentage():0.00}% ink remaining.");
    }
}
public class Pen
{
    public Pen(string brand, string colour, float maxInk)
    {
        this.Brand = brand;
        this.Colour = colour;
        this.InkLevel = maxInk;
        this.MaxInk = maxInk;
    }
    public string Brand { get; set; }
    public string Colour { get; set; }
    public float MaxInk { get; private set; }
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
    public float CalcRemainingInkPercentage()
    {
        return (float)Math.Round(InkLevel / MaxInk * 100, 2);
    }
    public void Write(int characters)
    {
        try
        {
            InkLevel -= characters * 0.1f;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"ERROR: {exception.Message}");
        }
    }
}
