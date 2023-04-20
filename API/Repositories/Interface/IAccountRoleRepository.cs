using API.Models;

namespace API.Repositories.Interface;

public interface IAccountRoleRepository
{
    IEnumerable<AccountRole> GetAll();
    AccountRole? GetById(int id);
    int Insert(AccountRole accountRole);
    int Update(AccountRole accountRole);
    int Delete(int id);
}
