using API.Models;

namespace API.Repositories.Interface;

public interface IAccountRepository
{
    IEnumerable<Account> GetAll();
    Account? GetById(string id);
    int Insert(Account account);
    int Update(Account account);
    int Delete(string id);
}
