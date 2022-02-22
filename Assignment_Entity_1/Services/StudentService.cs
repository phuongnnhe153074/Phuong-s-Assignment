using Assignment_Entity_1.Data;
using Assignment_Entity_1.Data.Entities;
namespace Assignment_Entity_1.Services;

public class StudentService : IStudentService
{
    private readonly MyDbContext _context;
    public StudentService(MyDbContext context)
    {
        _context = context;

    }
    public IList<Student> GetAll()
    {
        return _context.Students != null ? _context.Students.ToList() : new List<Student>();
    }
    public Student? GetOne(int id)
    {
        if (_context.Students == null)
        {
            return null;
        }
        return _context.Students.SingleOrDefault(x => x.Id == id);
    }
    public Student? Add(Student student)
    {
        if (_context.Students == null)
        {
            return null;
        }
        _context.Students.Add(student);
        _context.SaveChanges();
        return student;
    }

    public Student? Edit(int index, Student student)
    {
        if (index <= 0 && index > _context.Students.ToList().Count)
        {
           throw new IndexOutOfRangeException();
        }
         _context.Students.ToList()[index]= student;
         _context.SaveChanges();
         return student;
    }

    public void Remove(int index)
    {
        if(index <0 || index> _context.Students.ToList().Count) throw new IndexOutOfRangeException();

       _context.Students.ToList().RemoveAt(index-1);
       _context.SaveChanges();
    }
}