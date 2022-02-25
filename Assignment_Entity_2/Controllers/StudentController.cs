using Assignment_Entity_2.Models;
using Assignment_Entity_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Entity_2.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<StudentController> _logger;
    private readonly IStudentService _studentService;

    public StudentController(ILogger<StudentController> logger,IStudentService studentService)
    {
        _logger = logger;
        _studentService = studentService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var data = _studentService.GetAll();
        var results = from item in data 
                        select new StudentViewModel{
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            City = item.City
                        };
        return new JsonResult(results);
    }
    [HttpGet("{id:int}")]
    public IActionResult GetOne(int id)
    {
        var students = _studentService.GetOne(id);
        if (students == null)
        {
            return NotFound();
        }
        return new JsonResult(students);
    }
    
    [HttpPost]
    public IActionResult Create(StudentCreateModel model )

    {
        try
        {
            var entity = new Data.Entities.Student {
            FirstName = model.FirstName,
            LastName = model.LastName,
            City = model.City,
            State = model.State
        };
        var result = _studentService.Add(entity);
        return new JsonResult(result);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPut("{id:int}")]
    public IActionResult Update(int index, StudentCreateModel model )
    {
         try
        {
            var entity = _studentService.GetOne(index);
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.City = model.City;
            entity.State = model.State;
            _studentService.Edit(index, entity);
            return new JsonResult(entity);
        }
        catch (IndexOutOfRangeException ex)
        {
            // return NotFound(ex);
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpDelete("{index:int}")]
    public IActionResult Remove(int index)
    {
        try
        {
            var person = _studentService.GetOne(index);
            return Ok();
        }
        catch (IndexOutOfRangeException ex)
        {
            // return NotFound(ex);
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }

}
