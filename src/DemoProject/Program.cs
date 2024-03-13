namespace DemoProject;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Environment.UserName);
        Console.WriteLine(Environment.MachineName);
        Console.WriteLine(Environment.OSVersion);
        Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
    }
}
