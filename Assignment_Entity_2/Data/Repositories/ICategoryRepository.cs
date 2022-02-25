using Assignment_Entity_2.Data.Entities;

namespace Assignment_Entity_2.Data.Repositories;


public interface ICategoryRepository : IGenericRepository<Category>{
    Task<IEnumerable<Category>> GetAllIncludeAsync();
}