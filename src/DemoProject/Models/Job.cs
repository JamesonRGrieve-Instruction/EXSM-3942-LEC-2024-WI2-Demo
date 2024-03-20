using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models;

[Table("job")]
public class Job
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id", TypeName = "int(10)")]
    public int ID { get; set; }
    [Column("name", TypeName = "varchar(30)")]
    public string Name { get; set; } = "";

    [InverseProperty(nameof(Person.Job))]
    public virtual ICollection<Person> People { get; set; }
}