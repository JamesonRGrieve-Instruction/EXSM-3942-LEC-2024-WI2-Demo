using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DemoProject.Models;

public partial class EducationContext : DbContext
{
    public EducationContext()
    {
    }

    public EducationContext(DbContextOptions<EducationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=dbfirst_demo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Program).WithMany(p => p.Courses).HasConstraintName("course_ibfk_1");

            entity.HasData([
                new Course() {
                    Id = -1,
                    Code = "EXSM3931",
                    Name = "Introduction to Web Development",
                    ProgramId = -1
                },
            ]);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Section).WithMany(p => p.Enrollments).HasConstraintName("enrollment_ibfk_2");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments).HasConstraintName("enrollment_ibfk_1");

            entity.HasData([
                new Enrollment() {
                    Id = -1,
                    StudentId = -1,
                    SectionId = -1,
                    Grade = null
                },
            ]);
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasData([
                new Program() {
                    Id = -1,
                    Name = "Fullstack Web Application Development",
                },
            ]);
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Course).WithMany(p => p.Sections).HasConstraintName("section_ibfk_1");

            entity.HasOne(d => d.Semester).WithMany(p => p.Sections).HasConstraintName("section_ibfk_2");

            entity.HasData([
                new Section() {
                    Id = -1,
                    CourseId = -1,
                    SemesterId = -1,
                    DaysOffered = "MR",
                    TimeOffered = new TimeOnly(19, 0)
                },
            ]);
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasData([
                new Semester() {
                    Id = -1,
                    Name = "Winter 2024",
                    StartDate = new DateOnly(2024, 1, 8),
                    EndDate = new DateOnly(2024, 4, 26)
                },
            ]);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasData([
                new Student() {
                    Id = -1,
                    Firstname = "John",
                    Lastname = "Doe",
                    Birthdate = new DateOnly(1990,1,1)
                },
            ]);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
