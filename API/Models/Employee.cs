using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_m_employees")]
public class Employee
{
    [Key, Column("nik", TypeName = "char(5)")]
    public string NIK { get; set; }
    [Column("first_name", TypeName = "varchar(50)")]
    public string FirstName { get; set; }
    [Column("last_name", TypeName = "varchar(50)")]
    public string? LastName { get; set; }
    [Column("birth_date", TypeName = "datetime")]
    public DateTime BirthDate { get; set; }
    [Column("gender")]
    public Gender Gender { get; set; }
    [Column("hiring_date", TypeName = "datetime")]
    public DateTime HiringDate { get; set; }
    [Column("email", TypeName = "varchar(50)")]
    public string Email { get; set; }
    [Column("phone_number", TypeName = "varchar(50)")]
    public string PhoneNumber { get; set; }

    // Cardinality
    [JsonIgnore]
    public Profiling? Profiling { get; set; }
    [JsonIgnore]
    public Account? Account { get; set; }
}
public enum Gender
{
    Male,
    Female
}
