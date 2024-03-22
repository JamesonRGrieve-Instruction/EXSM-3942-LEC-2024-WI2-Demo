using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DotNetEnv;
using System.Diagnostics;
using System.Reflection;
namespace DemoProject.Models;

public partial class DemoProjectContext : DbContext
{
    public DemoProjectContext()
    {

    }
    public DemoProjectContext(DbContextOptions<DemoProjectContext> options) : base(options)
    {

    }
    public virtual DbSet<Person> People { get; set; }
    public virtual DbSet<Job> Jobs { get; set; }


    public static void LoadEnvironment()
    {
        try
        {
            string fileName = ".env";
            string path = fileName;
            while (!File.Exists(path) && !(Path.GetFullPath(path) == Path.GetPathRoot(Path.GetFullPath(path)) + fileName))
            {
                Console.WriteLine("Full Path: " + Path.GetFullPath(path));
                Console.WriteLine("Root Path: " + Path.GetPathRoot(Path.GetFullPath(path)) + fileName);
                path = "../" + path;
            }
            Env.Load(path);
        }
        catch
        {
            Console.WriteLine("ERROR: Failed to find .env!");
        }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        LoadEnvironment();
        string envDBType = Environment.GetEnvironmentVariable("DB_TYPE") ?? "";

        if (!optionsBuilder.IsConfigured)
        {
            if (envDBType.Trim().ToLower() == "mariadb" || envDBType.Trim().ToLower() == "mysql")
            {
                optionsBuilder.UseMySql($"Server={Environment.GetEnvironmentVariable("DB_HOST") ?? ""};" +
                    $"Port=3306;" +
                    $"Database={Environment.GetEnvironmentVariable("DB_NAME") ?? ""};UID=root;PWD=;", new MariaDbServerVersion("10.4.28-MariaDB"));
            }
            else if (envDBType.Trim().ToLower() == "postgres")
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=postgres;UID=postgres;PWD=password");
            }
            else
            {
                string dbName = "example.db";
                string exactPath = Path.Combine(Directory.GetCurrentDirectory(), dbName);
                if (!File.Exists(exactPath))
                {
                    File.Create(exactPath).Close();
                }
                optionsBuilder.UseSqlite($"Filename={dbName};");
            }
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasData([
                new Job() {
                    ID = -1,
                    Name = "Bus Driver"
                }
            ]);
        });

        modelBuilder.Entity<Person>(entity => // A Person
        {
            entity.HasOne(child => child.Job) // Has One Job
                .WithMany(parent => parent.People) // With Many People
                .HasForeignKey(child => child.JobID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{nameof(Person)}_{nameof(Job)}");

            entity.HasIndex(entity => entity.JobID)
                .HasDatabaseName($"FK_{nameof(Person)}_{nameof(Job)}");

            entity.HasData(
                [
                    new Person() {
                        ID = -1,
                        FirstName = "John",
                        LastName = "Doe",
                        JobID = -1
                    },
                    new Person() {
                        ID = -2,
                        FirstName = "Jane",
                        LastName = "Doe",
                        JobID = -1
                    },
                ]
            );
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}