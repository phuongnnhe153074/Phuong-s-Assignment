using Assignment_mvc_2.Models;

namespace Assignment_mvc_2.Services;


public class PersonService : IPersonService
{
    static List<Person> _people = new List<Person>(){
        new Person{
                firstname="Phuong",
                lastname="Nguyen Nam",
                gender="Male",
                age=21,
                address="Phu Tho"
            },
            new Person{
                firstname="Nam",
                lastname="Nguyen Thanh",
                gender="Male",
                age=20,
                address="Ha Noi"
            }
            };
    public List<Person> GetAll()
    {
        return _people;
    }
    public void Create(Person person)
    {
       _people.Add(person);
    }
    public Person GetOne(int index)
    {
        if(index <=0 && index> _people.Count) throw new IndexOutOfRangeException();
        return _people[index-1];
    }
 public void Update(int index,Person person)
    {
      if (index <= 0 && index > _people.Count)
        {
           throw new IndexOutOfRangeException();
        }
         _people[index]= person;
    }
    public void Delete(int index)
    {
       _people.RemoveAt(index-1);
    }

    
}