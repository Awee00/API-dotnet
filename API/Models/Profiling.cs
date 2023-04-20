using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_tr_profilings")]
public class Profiling
{
    [Key, Column("employee_nik", TypeName = "char(5)")]
    public string EmployeeNIK { get; set; }
    [Column("education_id")]
    public int EducationId { get; set; }

    // Cardinality
    [JsonIgnore]
    public Education? Education { get; set; }
    [JsonIgnore]
    public Employee? Employee { get; set; }
}
