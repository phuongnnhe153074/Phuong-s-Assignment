using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_mvc_2.Models;

namespace Assignment_mvc_2.Controllers;

public class PeopleController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public PeopleController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    static List<Person> people = new List<Person>(){
        new Person{
                firstname="a",
                lastname="a",
                gender="female",
                age=10,
                address="hanoi"
            },
            new Person{
                firstname="b",
                lastname="a",
                gender="female",
                age=20,
                address="hanoi"
            }
            };
    public IActionResult Index()
    {

        return View(people);
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
        people.Add(model);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int index)
    {
        if (index <= 0 && index > people.Count)
        {
            return RedirectToAction("Index");
        }
        var person = people[index - 1];
        return View(person);
    }

public IActionResult Delete(int index)
    {
        if (index <= 0 && index > people.Count)
        {
            return RedirectToAction("Index");
        }
        var person = people[index - 1];
        people.Remove(person);
        return RedirectToAction("Index");

    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}