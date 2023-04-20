using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        var employees = _employeeRepository.GetAll();
        return Ok(new ResponseDataVM<IEnumerable<Employee>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success",
            Data = employees
        });
    }

    [HttpGet("{id}")]
    public ActionResult GetById(String id)
    {
        var employee = _employeeRepository.GetById(id);
        if (employee == null)
            return NotFound(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Errors = "Id Not Found"
            });
        return Ok(new ResponseDataVM<Employee>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success",
            Data = employee
        });
    }

    [HttpPost]
    public ActionResult Insert(Employee employee)
    {
        if (employee.NIK == "" || employee.FirstName == "" || employee.BirthDate == null || employee.Gender == null || employee.HiringDate == null || employee.Email == "")
        {
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Errors = "Value Cannot be Null or Default"
            });
        }

        var insert = _employeeRepository.Insert(employee);
        if (insert > 0)
            return Ok(new ResponseDataVM<Employee>
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
    public ActionResult Update(Employee employee)
    {
        if (employee.FirstName == "" || employee.BirthDate == null || employee.Gender == null || employee.HiringDate == null || employee.Email == "")
        {
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Errors = "Value Cannot be Null or Default"
            });
        }

        var update = _employeeRepository.Update(employee);
        if (update > 0)
            return Ok(new ResponseDataVM<Employee>
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
    public ActionResult Delete(string id)
    {
        var delete = _employeeRepository.Delete(id);
        if (delete > 0)
            return Ok(new ResponseDataVM<Employee>
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
