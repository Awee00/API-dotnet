using API.Models;

namespace API.Repositories.Interface;

public interface IEmployeeRepository : IGeneralRepository<Employee, string>
{
    string GetFullNameByEmail(string email);
}
