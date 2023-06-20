using API.Models;
using Client.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class UniversityController : Controller
{
    private readonly UniversityRepository repository;

    public UniversityController(UniversityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var Results = await repository.Get();
        var universities = new List<University>();

        if (Results != null)
        {
            universities = Results.Data.ToList();
        }

        return View(universities);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(University university)
    {

        var result = await repository.Post(university);
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
        //localhost/university/
        var Results = await repository.Get(id);
        //var universities = new University();

        //if (Results != null)
        //{
        //    universities = Results.Data;
        //}

        return View(Results.Data);
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var Results = await repository.Get(id);
        return View(Results.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, University university)
    {
        var result = await repository.Put(id, university);
        if (result.Code == 200)
        {
            TempData["Success"] = "Data berhasil diubah";
            return RedirectToAction(nameof(Index));
        }
        else if (result.Code == 404)
        {
            TempData["Success"] = "Data tidak ditemukan";
            return RedirectToAction(nameof(Index));
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var Results = await repository.Get(id);
        return View(Results.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, University university)
    {
        var result = await repository.Delete(id);
        if (result.Code == 200)
        {
            TempData["Success"] = "Data berhasil dihapus";
            return RedirectToAction(nameof(Index));
        }
        else if (result.Code == 404)
        {
            TempData["Success"] = "Data tidak ditemukan";
            return RedirectToAction(nameof(Index));
        }

        return View();
    }
}
