using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_tr_account_roles")]
public class AccountRole
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Column("account_nik", TypeName = "char(5)")]
    public string AccountNIK { get; set; }
    [Column("role_id")]
    public int RoleId { get; set;}

    // Cardinality
    [JsonIgnore]
    public Account? Account { get; set; }
    [JsonIgnore]
    public Role? Role { get; set; }
}
