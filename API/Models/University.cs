using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_m_universities")]
public class University
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Column("name", TypeName = "varchar(100)")]
    public string Name { get; set; }
}
