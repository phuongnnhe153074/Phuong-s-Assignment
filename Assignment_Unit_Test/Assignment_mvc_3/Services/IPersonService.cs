using Assignment_mvc_2.Models;
namespace Assignment_mvc_2.Services;
 public interface IPersonService
 {
     List<Person> GetAll();
     Person GetOne(int index);
void Create(Person person);
void Update(int index, Person person);
void Delete(int Index);
 }