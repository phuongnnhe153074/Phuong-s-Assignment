using Assignment_Entity_2.Data.Entities;
namespace Assignment_Entity_2.Data.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    T? Get(int id);
    Task<T?> GetAsync(int id);
    T Insert(T entity);
    Task<T> InsertAsync(T entity);
    T Update(T entity);
    Task<T> UpdateAsync(T entity);
    
    void Delete(T entity);
    Task DeleteAsync(T entity);

}