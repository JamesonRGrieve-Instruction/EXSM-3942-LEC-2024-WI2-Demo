using DemoProject.Models;
namespace DemoProject;

class Program
{

    static void Main(string[] args)
    {
        DemoProjectContext context = new DemoProjectContext();
        Console.WriteLine(context.Database.CanConnect());
    }
}
