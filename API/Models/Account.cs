using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_m_accounts")]
public class Account
{
    [Key, Column("employee_nik", TypeName = "Char(5)")]
    public string EmployeeNIK { get; set; }
    [Column("password", TypeName = "varchar(255)")]
    public string Password { get; set; }

    // Cardinality
    public Employee Employee { get; set; }
    public ICollection<AccountRole> AccountRoles { get; set; }
}
