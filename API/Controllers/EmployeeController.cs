using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : GeneralController<IEmployeeRepository, Employee, string>
{
    public EmployeeController(IEmployeeRepository repository) : base(repository) { }
}
