using API.Repositories;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Base;

[Route("api/[controller]")]
[ApiController]
public class GeneralController<TRepository, TEntity, TKey> : ControllerBase
    where TRepository : IGeneralRepository<TEntity, TKey>
{
    protected readonly TRepository _repository;

    public GeneralController(TRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        var results = _repository.GetAll();
        if (results == null)
            return NotFound(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Errors = "Id Not Found"
            });
        return Ok(new ResponseDataVM<IEnumerable<TEntity>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success",
            Data = results
        });
    }

    [HttpGet("{key}")]
    public ActionResult GetById(TKey key)
    {
        var results = _repository.GetByKey(key);
        if (results == null)
            return NotFound(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Errors = "Id Not Found"
            });
        return Ok(new ResponseDataVM<TEntity>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success",
            Data = results
        });
    }

    [HttpPost]
    public ActionResult Insert(TEntity entity)
    {
        //if (entity.Name == "" || entity.Name.ToLower() == "string")
        //{
        //    return BadRequest(new ResponseErrorsVM<string>
        //    {
        //        Code = StatusCodes.Status400BadRequest,
        //        Status = HttpStatusCode.BadRequest.ToString(),
        //        Errors = "Value Cannot be Null or Default"
        //    });
        //}

        var insert = _repository.Insert(entity);
        if (insert > 0)
            return Ok(new ResponseDataVM<TEntity>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Insert Success"
            });
        return BadRequest(new ResponseErrorsVM<string>
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Errors = "Insert Failed / Lost Connection"
        });
    }

    [HttpPut]
    public ActionResult Update(TEntity entity)
    {
        //if (entity.Name == "" || entity.Name.ToLower() == "string")
        //{
        //    return BadRequest(new ResponseErrorsVM<string>
        //    {
        //        Code = StatusCodes.Status400BadRequest,
        //        Status = HttpStatusCode.BadRequest.ToString(),
        //        Errors = "Value Cannot be Null or Default"
        //    });
        //}

        var update = _repository.Update(entity);
        if (update > 0)
            return Ok(new ResponseDataVM<TEntity>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Update Success"
            });
        return BadRequest(new ResponseErrorsVM<string>
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Errors = "Insert Failed / Lost Connection"
        });
    }

    [HttpDelete("{key}")]
    public ActionResult Delete(TKey key)
    {
        var delete = _repository.Delete(key);
        if (delete > 0)
            return Ok(new ResponseDataVM<TEntity>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Delete Success"
            });
        return BadRequest(new ResponseErrorsVM<string>
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Errors = "Insert Failed / Lost Connection"
        });
    }
}
