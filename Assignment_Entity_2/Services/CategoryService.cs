using Assignment_Entity_2.Data;
using Assignment_Entity_2.Data.Entities;
using Assignment_Entity_2.Data.Repositories;

namespace Assignment_Entity_2.Services;

public interface ICategoryService{
    public Task<IList<Category>> GetAllAsync();
    
    public Task<Category?> GetOneAsync(int id);
    public Task<Category?> AddAsync(Category student);

    public Task<Category?> EditAsync(int index ,Category student);

    public Task RemoveAsync(int id);




}
public class CategoryService : ICategoryService
{
    
    private readonly CategoryRepository _repository;
    public CategoryService(CategoryRepository repository)
    {
        _repository = repository;
    }

    public Category? Add(Category student)
    {
        throw new NotImplementedException();
    }

    public Task<Category?> AddAsync(Category student)
    {
        throw new NotImplementedException();
    }

    public Category? Edit(int index, Category student)
    {
        throw new NotImplementedException();
    }

    public Task<Category?> EditAsync(int index, Category student)
    {
        throw new NotImplementedException();
    }

    public IList<Category> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Category>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();
        return data.ToList();
    }

    public Category? GetOne(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Category?> GetOneAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int id)
    {
        throw new NotImplementedException();
    }
}