using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class ProfilingRepository : GeneralRepository<Profiling, string, MyContext>, IProfilingRepository
{
    public ProfilingRepository(MyContext context) : base(context) { }
}
