using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversityController : ControllerBase
{
    private readonly IUniversityRepository _universityRepository;
    public UniversityController(IUniversityRepository universityRepository)
    {
        _universityRepository = universityRepository;
    }
    [HttpGet]
    public ActionResult GetAll()
    {
        var universities = _universityRepository.GetAll();
        return Ok(new ResponseDataVM<IEnumerable<University>>{
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success",
            Data = universities
        });
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        var university = _universityRepository.GetById(id);
        if (university == null)
            return NotFound(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Errors = "Id Not Found"
            });
        return Ok(new ResponseDataVM<University>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success",
            Data = university
        });
    }

    [HttpPost]
    public ActionResult Insert(University university)
    {
        if (university.Name == "" || university.Name.ToLower() == "string")
        {
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Errors = "Value Cannot be Null or Default"
            });
        }

        var insert = _universityRepository.Insert(university);
        if (insert > 0)
            return Ok(new ResponseDataVM<University>
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
    public ActionResult Update(University university)
    {
        if (university.Name == "" || university.Name.ToLower() == "string")
        {
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Errors = "Value Cannot be Null or Default"
            });
        }

        var update = _universityRepository.Update(university);
        if (update > 0)
            return Ok(new ResponseDataVM<University>
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
        var delete = _universityRepository.Delete(id);
        if (delete > 0)
            return Ok(new ResponseDataVM<University>
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
