using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_mvc_2.Models;
using Assignment_mvc_2.Services;
namespace Assignment_mvc_2.Controllers;

public class PeopleController : Controller
{
    private readonly IPersonService _personService;
    public PeopleController(IPersonService personService)
    {
        _personService = personService;
    }

    public IActionResult Index()
    {
        var person = _personService.GetAll();
        return View(person);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Person model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _personService.Create(model);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int index)
    {
        try
        {
            var person = _personService.GetOne(index);
            ViewBag.index=index;
            return View(person);
        }
        catch (System.Exception)
        {
            return RedirectToAction("Index");
        }


    }
    [HttpPost]
    public IActionResult Edit(int index, Person model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        _personService.Update(index, model);
        return RedirectToAction("Index");

    }

    
    public IActionResult Detail(int index)
    {
        try
        {
            var person = _personService.GetOne(index);
            ViewBag.index = index;
            return View(person);
        }
        catch (System.Exception)
        {
            return RedirectToAction("Index");
        }
    }
    public IActionResult Delete(int index)
    {
        try
        {
            _personService.Delete(index);
        }
        catch (System.Exception)
        {

        }
        return RedirectToAction("Index");

    }
 public IActionResult DeleteWithResult(int index)
    {
        var deletedUserName = string.Empty;
         try
        { 
            var person = _personService.GetOne(index);
            HttpContext.Session.SetString("DELETED_USER_NAME",person.lastname+" "+person.firstname);
            _personService.Delete(index);
            ViewBag.index = index;
            
        }
        catch (System.Exception)
        {

        }
        return RedirectToAction("Result");
    }
      public IActionResult Result()
    {
            var deletedUserName =HttpContext.Session.GetString("DELETED_USER_NAME");
            ViewBag.deletedUserName = deletedUserName;
            return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}