using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=test;UID=root;PWD=;", new MariaDbServerVersion("10.4.28-MariaDB"));
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