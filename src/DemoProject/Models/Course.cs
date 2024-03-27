using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models;

[Table("course")]
[Index("ProgramId", Name = "program_id")]
public partial class Course
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string? Name { get; set; }

    [Column("code")]
    [StringLength(50)]
    public string? Code { get; set; }

    [Column("program_id", TypeName = "int(11)")]
    public int? ProgramId { get; set; }

    [ForeignKey("ProgramId")]
    [InverseProperty("Courses")]
    public virtual Program? Program { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
