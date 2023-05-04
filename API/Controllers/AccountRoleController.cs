using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountRoleController : GeneralController<IAccountRoleRepository, AccountRole, int>
{
    public AccountRoleController(IAccountRoleRepository repository) : base(repository) { }
}
