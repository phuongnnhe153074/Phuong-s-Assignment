using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace assignment_ojt
{
    class Program
    {

        class Student
        {
            public string firstname;
            public string lastname;
            public string gender;
            public DateTime dob;
            public string phonenum;
            public string birthplace;
            public int age;
            public bool isGraduated;
            public Student(string firstname, String lastname, string gender, DateTime dob, string phonenum, string birthplace, bool isGraduated)
            {
                this.firstname = firstname;
                this.lastname = lastname;
                this.gender = gender;
                this.dob = dob;
                this.phonenum = phonenum;
                this.birthplace = birthplace;
                int countedAge = DateTime.Now.Year - dob.Year;
                this.age = countedAge;
                this.isGraduated = isGraduated;
            }

            public void Show()
            {
                Console.WriteLine("Firstname: " + firstname + " - Lastname: " + lastname + " - Gender:" + gender + " - Birth: " + dob.ToString("dd/MM/yyyy") + " - Age: " + age);
            }
        }
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            Student a1 = new Student("Phuong", "Nguyen Nam", "Male", DateTime.Parse("22/01/2001"), "0943746666", "Phu Tho", false);
            Student a2 = new Student("Nam", "Nguyen Thanh", "Male", DateTime.Parse("20/01/2001"), "", "Ha noi", false);
            Student a3 = new Student("Son", "Do Hong", "Male", DateTime.Parse("06/11/2000"), "", "Ha noi", false);
            Student a4 = new Student("Huy", "Nguyen Duc", "Male", DateTime.Parse("26/01/1996"), "", "Ha noi", false);
            Student a5 = new Student("Hoang", "Phuong Viet", "Male", DateTime.Parse("05/2/1999"), "", "Ha noi", false);
            Student a6 = new Student("Long", "Lai Quoc", "Male", DateTime.Parse("30/05/1997"), "", "Bac Giang", false);
            Student a7 = new Student("Thanh", "Tran Chi", "Male", DateTime.Parse("18/09/2000"), "", "Ha noi", false);


            list.Add(a1);
            list.Add(a2);
            list.Add(a3);
            list.Add(a4);
            list.Add(a5);
            list.Add(a6);
            list.Add(a7);

            while (true)
            {
                Console.WriteLine("ASSIGNMENT 1");
                Console.WriteLine("1. Find male student.");
                Console.WriteLine("2. Find the oldest");
                Console.WriteLine("3. Fullname list");
                Console.WriteLine("4. 3 different list");
                Console.WriteLine("5. Student was born in Hanoi");
                Console.WriteLine("Choose 1-5");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        var listMale = from student in list
                                       where student.gender == "Male"
                                       select student;
                        foreach (var o in listMale)
                        {
                            o.Show();

                        }
                        break;
                    case 2:
                        var order = (from student in list
                                     orderby student.dob descending
                                     select student).ToList();
                        Student oldest = order[order.Count - 1];
                        oldest.Show();
                        break;

                    case 3:
                        List<string> fullName = new List<string>();
                        foreach (var o in list)
                        {
                            string full = o.firstname + " " + o.lastname;
                            fullName.Add(full);
                        }
                        foreach (var a in fullName)
                        {
                            Console.WriteLine(a);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Equal 2000");
                        var equal = from student in list
                                    where student.dob.Year == 2000
                                    select student;
                        foreach (var item in equal)
                        {
                            item.Show();
                        }
                        Console.WriteLine("More than 2000");

                        var more = from student in list
                                   where student.dob.Year < 2000
                                   select student;
                        foreach (var item in more)
                        {
                            item.Show();
                        }
                        Console.WriteLine("Less than 2000");

                        var less = from student in list
                                   where student.dob.Year > 2000
                                   select student;
                        foreach (var item in less)
                        {
                            item.Show();
                        }
                        break;
                    case 5:
                        var born = from o in list
                                   where o.birthplace.Equals("Ha noi")
                                   select o;
                        foreach (var item in born)
                        {
                            item.Show();
                        }
                        break;
                    case 0:
                        return;
                }
            }
            Console.ReadLine();
        }
    }
}
