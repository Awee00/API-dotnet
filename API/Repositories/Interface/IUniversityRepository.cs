using API.Models;

namespace API.Repositories.Interface;

public interface IUniversityRepository
{
    IEnumerable<University> GetAll();
    University? GetById(int id);
    int Insert(University university);
    int Update(University university);
    int Delete(int id);
}
