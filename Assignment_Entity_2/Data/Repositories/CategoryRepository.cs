using Assignment_Entity_2.Data.Entities;

namespace Assignment_Entity_2.Data.Repositories;


public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(MyDbContext context) : base(context)
    {
        
    }

    public Task<IEnumerable<Category>> GetAllIncludeAsync()
    {
        throw new NotImplementedException();
        //    return await _entity.Include(c => c.Products).ToListAsync();
    }

}