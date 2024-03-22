﻿// <auto-generated />
using DemoProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoProject.Migrations
{
    [DbContext(typeof(DemoProjectContext))]
    [Migration("20240322011950_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DemoProject.Models.Job", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.HasKey("ID");

                    b.ToTable("job");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Name = "Bus Driver"
                        });
                });

            modelBuilder.Entity("DemoProject.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("first_name");

                    b.Property<int>("JobID")
                        .HasColumnType("int(10)")
                        .HasColumnName("job_id");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("last_name");

                    b.HasKey("ID");

                    b.HasIndex("JobID")
                        .HasDatabaseName("FK_Person_Job");

                    b.ToTable("person");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            FirstName = "John",
                            JobID = -1,
                            LastName = "Doe"
                        },
                        new
                        {
                            ID = -2,
                            FirstName = "Jane",
                            JobID = -1,
                            LastName = "Doe"
                        });
                });

            modelBuilder.Entity("DemoProject.Models.Person", b =>
                {
                    b.HasOne("DemoProject.Models.Job", "Job")
                        .WithMany("People")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Person_Job");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("DemoProject.Models.Job", b =>
                {
                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}
