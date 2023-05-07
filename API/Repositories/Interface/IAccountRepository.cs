using API.Models;
using API.ViewModels;

namespace API.Repositories.Interface;

public interface IAccountRepository : IGeneralRepository<Account, string>
{
    int Register(RegisterVM registerVM);

    bool Login(LoginVM loginVM);
}
