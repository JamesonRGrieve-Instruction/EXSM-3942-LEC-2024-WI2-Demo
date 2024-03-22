using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models;

[Table("classroom")]
public class ClassRoom
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int ID { get; set; }
    [Column("room_number")]
    public int RoomNumber { get; set; }

    [InverseProperty(nameof(Student.ClassRoom))]
    public virtual ICollection<Student>? Students { get; set; }
}