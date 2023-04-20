using API.Models;

namespace API.Repositories.Interface;

public interface IEducationRepository
{
    IEnumerable<Education> GetAll();
    Education? GetById(int id);
    int Insert(Education education);
    int Update(Education education);
    int Delete(int id);
}
