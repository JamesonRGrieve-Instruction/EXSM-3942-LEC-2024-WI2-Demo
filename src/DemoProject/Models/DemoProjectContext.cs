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


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Env.Load("../../../.env");

        string envDBType = Environment.GetEnvironmentVariable("DB_TYPE") ?? "";

        if (!optionsBuilder.IsConfigured)
        {
            if (envDBType.Trim().ToLower() == "mariadb" || envDBType.Trim().ToLower() == "mysql")
            {
                optionsBuilder.UseMySql($"Server={Environment.GetEnvironmentVariable("DB_HOST") ?? ""};Port=3306;Database={Environment.GetEnvironmentVariable("DB_NAME") ?? ""};UID=root;PWD=;", new MariaDbServerVersion("10.4.28-MariaDB"));
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
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasOne(child => child.Job)
                .WithMany(parent => parent.People)
                .HasForeignKey(child => child.JobID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{nameof(Person)}_{nameof(Job)}");

            entity.HasIndex(entity => entity.JobID)
                .HasDatabaseName($"FK_{nameof(Person)}_{nameof(Job)}");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}