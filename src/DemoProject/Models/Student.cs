using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models;

[Table("student")]
public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int ID { get; set; }
    [Column("first_name", TypeName = "varchar(30)")]
    public string FirstName { get; set; } = "";
    [Column("last_name", TypeName = "varchar(30)")]
    public string LastName { get; set; } = "";

    [Column("class_id")]
    public int ClassID { get; set; }

    [ForeignKey(nameof(ClassID))]
    [InverseProperty(nameof(Models.ClassRoom.Students))]
    public virtual ClassRoom ClassRoom { get; set; }
}