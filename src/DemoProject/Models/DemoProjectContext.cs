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
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<ClassRoom> ClassRooms { get; set; }


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
        string envDBType = Environment.GetEnvironmentVariable("DB_TYPE") ?? "",
        envDBHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "",
        envDBName = Environment.GetEnvironmentVariable("DB_NAME") ?? "",
        envMariaDBUser = Environment.GetEnvironmentVariable("MARIADB_USERNAME") ?? "",
        envMariaDBPassword = Environment.GetEnvironmentVariable("MARIADB_PASSWORD") ?? "";

        if (!optionsBuilder.IsConfigured)
        {
            if (envDBType.Trim().ToLower() == "mariadb" || envDBType.Trim().ToLower() == "mysql")
            {
                optionsBuilder.UseMySql($"Server={envDBHost};Port=3306;Database={envDBName};UID={envMariaDBUser};PWD={envMariaDBPassword};", new MariaDbServerVersion("10.4.28-MariaDB"));
            }
            else if (envDBType.Trim().ToLower() == "postgres")
            {
                optionsBuilder.UseNpgsql($"Server={envDBHost};Port=5432;Database={envDBName};UID=postgres;PWD=password");
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
        modelBuilder.Entity<ClassRoom>(entity =>
        {
            entity.HasData([
                new ClassRoom() {
                    ID = -1,
                    RoomNumber = 101
                },
                new ClassRoom() {
                    ID = -2,
                    RoomNumber = 102
                },

            ]);
        });

        modelBuilder.Entity<Student>(entity => // A Student
        {
            entity.HasOne(child => child.ClassRoom) // Has One ClassRoom
                .WithMany(parent => parent.Students) // With Many Students
                .HasForeignKey(child => child.ClassID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{nameof(Student)}_{nameof(ClassRoom)}");

            entity.HasIndex(entity => entity.ClassID)
                .HasDatabaseName($"FK_{nameof(Student)}_{nameof(ClassRoom)}");

            entity.HasData(
                [
                    new Student() {
                        ID = -1,
                        FirstName = "John",
                        LastName = "Doe",
                        ClassID = -1
                    },
                    new Student() {
                        ID = -2,
                        FirstName = "Jane",
                        LastName = "Doe",
                        ClassID = -1
                    },
                    new Student() {
                        ID = -3,
                        FirstName = "Tom",
                        LastName = "Doe",
                        ClassID = -1
                    },
                    new Student() {
                        ID = -4,
                        FirstName = "Bob",
                        LastName = "Doe",
                        ClassID = -2
                    },
                    new Student() {
                        ID = -5,
                        FirstName = "Joe",
                        LastName = "Doe",
                        ClassID = -2
                    },
                    new Student() {
                        ID = -6,
                        FirstName = "Paul",
                        LastName = "Doe",
                        ClassID = -2
                    },
                ]
            );
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}