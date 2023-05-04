using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationController : GeneralController<IEducationRepository, Education, int>
{
    public EducationController(IEducationRepository repository) : base(repository) { }
}
