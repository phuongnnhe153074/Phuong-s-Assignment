using Assignment_API_2.Models;
using Assignment_API_2.Services.Services;
using Assignment_API_2.Common;

using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Assignment_API_2.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly ILogger<PersonController> _logger;

    private readonly IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    // [HttpGet]
    // public List<Person> Filter(string? name, string? gender, string? address)
    // {
    //     var people = _personService.GetAll();
    //     Expression<Func<Person, bool>> predicate = x => true;
    //     if (!string.IsNullOrEmpty(name))
    //     {
    //         Expression<Func<Person, bool>> filterByName = x => (x.firstname != null && x.firstname.Contains(name, StringComparison.CurrentCulture)) ||
    //         x.lastname != null && x.lastname.Contains(name, StringComparison.CurrentCulture);

    //         predicate = predicate.And(filterByName);
    //     }
    //     var results = people.Where(predicate.);
    //     return results.ToList();
    // }
    [HttpGet]
    public List<Person> Filter(string? name, string? gender, string? address)
    {
        return _personService.GetAll();
    }
    [HttpGet("{index:int}")]
    public IActionResult GetOne(int index)
    {
        try
        {
            var person = _personService.GetOne(index);
            return new JsonResult(person);
        }
        catch (IndexOutOfRangeException ex)
        {
            // return NotFound(ex);
            _logger.LogError(ex, ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

    }
    [HttpPost]
    public Person Add(PersonCreateModel model)
    {
        var person = new Person
        {
            firstname = model.firstname,
            lastname = model.lastname,
            gender = model.gender,
            age = model.age,
            address = model.address
        };
        return _personService.Create(person);
    }
    [HttpPut("{index:int}")]
    public IActionResult Edit(int index, PersonUpdateModel model)
    {
        try
        {
            var person = _personService.GetOne(index);
            person.firstname = model.firstname;
            person.lastname = model.lastname;
            person.gender = model.gender;
            person.address = model.address;
            person.age = model.age;
            _personService.Update(index, person);
            return new JsonResult(person);
        }
        catch (IndexOutOfRangeException ex)
        {
            // return NotFound(ex);
            _logger.LogError(ex, ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
    [HttpDelete("{index:int}")]
    public IActionResult Remove(int index)
    {
        try
        {
            var person = _personService.GetOne(index);
            return Ok();
        }
        catch (IndexOutOfRangeException ex)
        {
            // return NotFound(ex);
            _logger.LogError(ex, ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

    }
    [HttpGet("filter-by-name")]
    public List<Person> FilterByName(string keyword)
    {
        var people = _personService.GetAll();
        var results = from person in people
                      where (person.firstname != null && person.firstname.Contains(keyword, StringComparison.CurrentCulture)) ||
                      person.lastname != null && person.lastname.Contains(keyword, StringComparison.CurrentCulture)
                      select person;
        return results.ToList();
    }
    [HttpGet("filter-by-gender")]
    public List<Person> FilterByGender(string gender)
    {
        var people = _personService.GetAll();
        var results = from person in people
                      where (person.gender.Equals(gender)&&person.gender!=null)
                      select person;
        return results.ToList();
    }
    [HttpGet("filter-by-addres")]

    public List<Person> FilterByAddress(string address)
    {
        var people = _personService.GetAll();
        var results = from person in people
                      where (person.address.Equals(address)&&person.address!=null)
                      select person;
        return results.ToList();
    }
}
