namespace DemoProject;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("For Loop");
        string toOutput = "";
        for (int i = 1; i <= 20; i++)
        {
            toOutput += i + "\n";
        }
        Console.WriteLine(toOutput);
        Console.WriteLine("Individual Recursive");
        WriteCountIndividual(1, 20);
        Console.WriteLine("Assembled Recursive");
        Console.WriteLine(WriteCountAssembled(1, 20));
    }

    static void WriteCountIndividual(int start, int end)
    {
        // Output the current value (start)
        Console.WriteLine(start);
        // If we aren't done, increment start and pass it forward to another call.
        if (start < end)
        {
            WriteCountIndividual(start + 1, end);
        }
    }

    static string WriteCountAssembled(int start, int end)
    {
        // If we aren't done, return the current value plus the incremented call.
        // This will suspend this method instance until its downstream counterparts are done.
        // This will only occur when one of these goes to the else branch and does not call another instance.
        if (start < end)
        {
            return $"{start}\n{WriteCountAssembled(start + 1, end)}";
        }
        // Once one does hit the else brance, it backfeeds up the stack, building the string from the end backward.
        else
        {
            return start.ToString();
        }
    }
}
