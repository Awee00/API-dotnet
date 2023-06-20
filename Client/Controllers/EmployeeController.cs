using API.Models;
using Client.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class EmployeeController : Controller
{
    private readonly EmployeeRepository repository;

    public EmployeeController(EmployeeRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var Results = await repository.Get();
        var employees = new List<Employee>();

        if (Results != null)
        {
            employees = Results.Data.ToList();
        }

        return View(employees);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Employee employee)
    {

        var result = await repository.Post(employee);
        if (result.Code == 200)
        {
            TempData["Success"] = "Data berhasil masuk";
            return RedirectToAction(nameof(Index));
        }
        else if (result.Code == 409)
        {
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        //localhost/employee/
        var Results = await repository.Get(id);
        //var employees = new Employee();

        if (Results != null)
        {
            //employees = Results.Data;
            return View(Results.Data);
        }

        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var Results = await repository.Get(id);
        //var employees = new Employee();

        if (Results != null)
        {
            //employees = Results.Data;
            return View(Results.Data);
        }

        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Employee employee)
    {
        var Results = await repository.Put(id, employee);
        //var employees = new Employee();

        if (Results != null)
        {
            //employees = Results.Data;
            return RedirectToAction(nameof(Index));
        }

        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var Results = await repository.Get(id);
        //var employees = new Employee();

        if (Results != null)
        {
            //employees = Results.Data;
            return View(Results.Data);
        }

        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, Employee employee)
    {
        var Results = await repository.Delete(id);
        //var employees = new Employee();

        if (Results != null)
        {
            //employees = Results.Data;
            return RedirectToAction(nameof(Index));
        }

        return NotFound();
    }
}
