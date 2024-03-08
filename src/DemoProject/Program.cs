namespace DemoProject;

class Program
{
    static void Main(string[] args)
    // Entry Point (Start)
    {
        WritingUtensil utensil = new Pencil("Dixon");
        Console.Write("Please select Pen or Pencil: ");
        string selection = Console.ReadLine();
        bool valid = false;
        if (selection.ToLower() == "pen")
        {
            utensil = new Pen("Bic", "Black", 50f);
            valid = true;
        }
        else if (selection.ToLower() == "pencil")
        {
            valid = true;
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
        if (valid)
        {
            string input = "";
            while (input != "exit")
            {
                Console.Write("Enter a number of characters, or exit: ");
                input = Console.ReadLine().Trim().ToLower();
                if (input != "exit")
                {
                    try
                    {
                        int characters = int.Parse(input);
                        utensil.Write(characters);
                        if (utensil.GetType() == typeof(Pencil))
                        {
                            Console.WriteLine($"There is {((Pencil)utensil).Length}% of the pencil remaining.");
                        }
                        else if (utensil.GetType() == typeof(Pen))
                        {
                            Console.WriteLine($"There is {((Pen)utensil).RemainingInkPercentage}% of the ink remaining.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

        }
        // Exit Point (End)
    }
}

public abstract class WritingUtensil
{
    public WritingUtensil(string brand)
    {
        this.Brand = brand;
    }
    public string Brand { get; set; }
    public abstract void Write(int characters);
}
public class Pencil : WritingUtensil
{
    public Pencil(string brand) : base(brand)
    {
        Length = 100f;
    }
    private float _length;
    public float Length
    {
        get
        {
            return _length;
        }
        set
        {
            // Validation
            if (value < 0)
            {
                throw new Exception("Length cannot be set to a negative value.");
            }
            else
            {
                _length = value;
            }
        }
    }
    public override void Write(int characters)
    {
        try
        {
            Length -= characters * 0.25f;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"ERROR: {exception.Message}");
        }
    }
}
// Class Definition
public class Pen : WritingUtensil
{
    // Constructor Definition
    public Pen(string brand, /*Constructor Parameters*/ string colour, float maxInk) : base(brand)
    {
        this.Colour = colour;
        this.InkLevel = maxInk;
        this.MaxInk = maxInk;
    }
    // Auto-Implemented Property

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

    public override void Write(int characters)
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
