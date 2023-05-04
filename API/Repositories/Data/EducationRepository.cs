using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class EducationRepository : GeneralRepository<Education, int, MyContext>, IEducationRepository
{
    public EducationRepository(MyContext context) : base(context) { }
}
