using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfilingController : GeneralController<IProfilingRepository, Profiling, string>
{
    public ProfilingController(IProfilingRepository repository) : base(repository) { }
}
