namespace DemoProject;

class Program
{
    static void Main(string[] args)
    // Entry Point (Start)
    {
        // Instantiation
        Pen pen = new Pen("Bic", "Blue", 80f);
        // Method Call
        pen.Write(100);
        pen.Write(42);
        pen.Write(200);
        // Output
        Console.WriteLine($"The pen has {pen.InkLevel:0.00}mL of ink remaining, {pen.CalcRemainingInkPercentage():0.00}% ink remaining.");
        // Exit Point (End)
    }
}
// Class Definition
public class Pen
{
    // Constructor Definition
    public Pen(string brand /*Constructor Parameters*/, string colour, float maxInk)
    {
        this.Brand = brand;
        this.Colour = colour;
        this.InkLevel = maxInk;
        this.MaxInk = maxInk;
    }
    // Auto-Implemented Property
    public string Brand { get; set; }
    public string Colour { get; set; }
    // Auto-Implemented Property w/ Private Setter
    public float MaxInk { get; private set; }
    // Private Field
    private float _inkLevel;
    // Fully Implemented Property
    public float InkLevel
    {
        // Accessor
        get
        {
            return _inkLevel;
        }
        // Mutator (Private)
        private set
        {
            // Validation
            if (value < 0)
            {
                throw new Exception("InkLevel cannot be set to a negative value.");
            }
            // 'value' is a keyword representing the inbound value.
            this._inkLevel = value;
        }
    }

    // Derived Property
    public float RemainingInkPercentage
    {
        get
        {
            return (float)Math.Round(InkLevel / MaxInk * 100, 2);
        }
    }

    // Method (Function) Definitions
    // public float CalcRemainingInkPercentage()
    // {
    //     return (float)Math.Round(InkLevel / MaxInk * 100, 2);
    // }

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
