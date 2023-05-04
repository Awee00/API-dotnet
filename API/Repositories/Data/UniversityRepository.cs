using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class UniversityRepository : GeneralRepository<University, int, MyContext>, IUniversityRepository
{
    public UniversityRepository(MyContext context) : base(context) { }
}
