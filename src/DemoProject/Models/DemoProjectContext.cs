using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoProject.Models;

public class DemoProjectContext : DbContext
{
    public DemoProjectContext()
    {

    }
    public DemoProjectContext(DbContextOptions<DemoProjectContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=test;UID=root;PWD=;", new MariaDbServerVersion("10.4.28-MariaDB"));
        }
    }
}