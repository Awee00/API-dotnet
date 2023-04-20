using API.Models;

namespace API.Repositories.Interface;

public interface IProfilingRepository
{
    IEnumerable<Profiling> GetAll();
    Profiling? GetById(string id);
    int Insert (Profiling profiling);
    int Update(Profiling profiling);
    int Delete(string id);
}
