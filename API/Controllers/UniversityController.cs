using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversityController : GeneralController<IUniversityRepository, University, int>
{
    public UniversityController(IUniversityRepository repository) : base(repository) { }
}
