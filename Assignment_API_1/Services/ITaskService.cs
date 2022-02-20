using Assignment_API_1.Models;  
using Task = Assignment_API_1.Models.Task;
 
namespace Assignment_API_1.Services;
public interface ITaskService{
    List<Task> GetAll();
    Task? GetOne(Guid id);
    Task Add(Task task);
    
    Task Edit(Task task);
    void Remove(Guid id);
    List<Task> Add(List<Task> tasks);
    void Remove(List<Guid> ids);
    bool Exists(Guid id);
}