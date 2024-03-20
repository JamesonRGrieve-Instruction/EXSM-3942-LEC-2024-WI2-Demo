using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models;

[Table("example_table")]
public class ExampleTable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id", TypeName = "int(10)")]
    public int ID { get; set; }
    [Column("first_name", TypeName = "varchar(30)")]
    public string FirstName { get; set; } = "";
    [Column("last_name", TypeName = "varchar(30)")]
    public string LastName { get; set; } = "";
}