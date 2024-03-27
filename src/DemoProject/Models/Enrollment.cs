using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models;

[Table("enrollment")]
[Index("SectionId", Name = "section_id")]
[Index("StudentId", Name = "student_id")]
public partial class Enrollment
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("student_id", TypeName = "int(11)")]
    public int? StudentId { get; set; }

    [Column("section_id", TypeName = "int(11)")]
    public int? SectionId { get; set; }

    [ForeignKey("SectionId")]
    [InverseProperty("Enrollments")]
    public virtual Section? Section { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Enrollments")]
    public virtual Student? Student { get; set; }
}
