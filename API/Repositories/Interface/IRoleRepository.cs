using API.Models;

namespace API.Repositories.Interface;

public interface IRoleRepository
{
    IEnumerable<Role> GetAll();
    Role? GetById(int id);
    int Insert(Role role);
    int Update(Role role);
    int Delete(int id);
}
