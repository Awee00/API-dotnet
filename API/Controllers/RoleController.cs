using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleRepository _roleRepository;

    public RoleController(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        var roles = _roleRepository.GetAll();
        return Ok(new ResponseDataVM<IEnumerable<Role>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success",
            Data = roles
        });
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        var role = _roleRepository.GetById(id);
        if (role == null)
            return NotFound(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Errors = "Id Not Found"
            });
        return Ok(new ResponseDataVM<Role>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success",
            Data = role
        });
    }

    [HttpPost]
    public ActionResult Insert(Role role)
    {
        if (role.Name == "" || role.Name.ToLower() == "string")
        {
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Errors = "Value Cannot be Null or Default"
            });
        }

        var insert = _roleRepository.Insert(role);
        if (insert > 0)
            return Ok(new ResponseDataVM<Role>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Insert Success",
                Data = null!
            });
        return BadRequest(new ResponseErrorsVM<string>
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Errors = "Insert Failed / Lost Connection"
        });
    }

    [HttpPut]
    public ActionResult Update(Role role)
    {
        if (role.Name == "" || role.Name.ToLower() == "string")
        {
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Errors = "Value Cannot be Null or Default"
            });
        }

        var update = _roleRepository.Update(role);
        if (update > 0)
            return Ok(new ResponseDataVM<Role>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Update Success",
                Data = null!
            });
        return BadRequest(new ResponseErrorsVM<string>
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Errors = "Insert Failed / Lost Connection"
        });
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        var delete = _roleRepository.Delete(id);
        if (delete > 0)
            return Ok(new ResponseDataVM<Role>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Delete Success",
                Data = null!
            });
        return BadRequest(new ResponseErrorsVM<string>
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Errors = "Insert Failed / Lost Connection"
        });
    }
}
