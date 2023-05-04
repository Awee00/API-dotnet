using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : GeneralController<IRoleRepository, Role, int>
{
    public RoleController(IRoleRepository repository) : base(repository) { }
}
