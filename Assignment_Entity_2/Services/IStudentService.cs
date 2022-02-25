using Assignment_Entity_2.Data.Entities;
namespace Assignment_Entity_2.Services;
public interface IStudentService{
    public IList<Student> GetAll();
    
    public Student? GetOne(int id);
    public Student? Add(Student student);

    public Student? Edit(int index ,Student student);

    public void Remove(int id);




}