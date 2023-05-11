using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class AccountRoleRepository : GeneralRepository<AccountRole, int, MyContext>, IAccountRoleRepository
{
    public AccountRoleRepository(MyContext context) : base(context) { }

    public IEnumerable<string> GetRolesByEmail(string email)
    {
        var EmployeeNIK = _context.Employees.FirstOrDefault(e => e.Email == email).NIK;
        var AccountRoles = _context.AccountRoles
            .Where(ar => ar.AccountNIK == EmployeeNIK)
            .Join(_context.Roles, ar => ar.RoleId, r => r.Id, (ar, r) => new {ar, r})
            .Select(role => role.r.Name);

        return AccountRoles;
    }
}
