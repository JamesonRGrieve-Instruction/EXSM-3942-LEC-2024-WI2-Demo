using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models;

[Table("section")]
[Index("CourseId", Name = "course_id")]
[Index("SemesterId", Name = "semester_id")]
public partial class Section
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("course_id", TypeName = "int(11)")]
    public int? CourseId { get; set; }

    [Column("semester_id", TypeName = "int(11)")]
    public int? SemesterId { get; set; }

    [Column("days_offered")]
    [StringLength(50)]
    public string? DaysOffered { get; set; }

    [Column("time_offered", TypeName = "time")]
    public TimeOnly? TimeOffered { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Sections")]
    public virtual Course? Course { get; set; }

    [InverseProperty("Section")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    [ForeignKey("SemesterId")]
    [InverseProperty("Sections")]
    public virtual Semester? Semester { get; set; }
}
