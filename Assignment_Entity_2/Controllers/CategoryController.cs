using Assignment_Entity_2.Data.Repositories;
using Assignment_Entity_2.Models;
using Assignment_Entity_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Entity_2.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryRepository _repository;

    public CategoryController(ILogger<CategoryController> logger, ICategoryRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _repository.GetAllAsync();
        var results = from item in data
                      select new CategoryViewModel
                      {
                          Id = item.Id,
                          Name = item.Name,
                          products = from p in item.Products
                                     select new ProductViewModel
                                     {
                                         Id = p.Id,
                                         Name = p.Name,
                                         Manufacture = p.Manufacture
                                     }
                      };
        return new JsonResult(results);
    }
    [HttpGet("{id:int}")]
    public IActionResult GetOne(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateModel model)

    {
        try
        {
            var entity = new Data.Entities.Category
            {
                Name = model.Name,
                Products = (from p in model.products
                            select new Data.Entities.Product
                            {
                                Name = p.Name,
                                Manufacture = p.Manufacture
                            }).ToList()
            };
            var result = _repository.InsertAsync(entity);
            return new JsonResult(new CategoryViewModel
            {
                Id = result.Id
            });
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }
    [HttpPut("{id:int}")]
    public IActionResult Update(int index, StudentCreateModel model)
    {
        throw new NotImplementedException();

    }
    [HttpDelete("{index:int}")]
    public IActionResult Remove(int index)
    {

        throw new NotImplementedException();

    }

}
