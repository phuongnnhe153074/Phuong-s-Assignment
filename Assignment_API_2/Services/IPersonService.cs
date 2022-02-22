using Assignment_API_2.Models;
namespace Assignment_API_2.Services.Services;
 public interface IPersonService
 {
     List<Person> GetAll();
     Person GetOne(int index);
Person Create(Person person);
Person Update(int index, Person person);
void Delete(int index);
 }