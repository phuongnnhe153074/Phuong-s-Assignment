using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Assignment_5.Models;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assignment_5.Controllers
{
    public class RookiesController : Controller
    {
        static List<Person> list = new List<Person>
        {
            new Person{firstname="Phuong", lastname="Nguyen Nam", gender="Male",dob= DateTime.Parse("22/01/2001"),phonenum= "0943746666",birthplace= "Phu Tho",isGraduated= false},
             new Person{ firstname="Nam", lastname="Nguyen Thanh",gender= "Male",dob= DateTime.Parse("20/01/2001"), phonenum= "", birthplace="Ha noi", isGraduated= false},
             new Person{firstname= "Son", lastname="Do Hong",gender= "Male", dob= DateTime.Parse("06/11/2000"), phonenum="",birthplace= "Ha noi",isGraduated= false},
            new Person{firstname="Huy",lastname= "Nguyen Duc",gender=  "Male", dob= DateTime.Parse("26/01/1996"),phonenum= "",birthplace=  "Ha noi",isGraduated= false},
            new Person{firstname="Hoang", lastname="Phuong Viet", gender="Male",dob= DateTime.Parse("05/2/1999"),phonenum= "",birthplace=  "Ha noi",isGraduated= false},
            new Person{firstname="Long", lastname="Lai Quoc",gender= "Male",dob= DateTime.Parse("30/05/1997"),phonenum= "",birthplace=  "Bac Giang",isGraduated= false},
             new Person{firstname="Thanh",lastname= "Tran Chi",gender= "Male",dob= DateTime.Parse("18/09/2000"),phonenum= "",birthplace=  "Ha noi",isGraduated= false},
        };
    //       public IActionResult Index()
    // {
    //     return View();
    // }
        [Route("NashTech/rookies/male")]
        public IActionResult GetMaleMember()
        {
            var listMale = from student in list
                           where student.gender == "Male"
                           select student;
            return new ObjectResult(listMale);
        }
        [Route("NashTech/rookies/oldest")]
        public IActionResult GetOldestMember()
        {
            var order = (from student in list
                         orderby student.dob descending
                         select student).ToList();
            Person oldest = order[order.Count - 1];
            return new ObjectResult(oldest);
        }
        [Route("NashTech/rookies/full")]
        public IActionResult GetFullMember()
        {
            List<string> fullName = new List<string>();
            foreach (var o in list)
            {
                string full = o.firstname + " " + o.lastname;
                fullName.Add(full);
            }
            return new ObjectResult(fullName);
        }
        [Route("NashTech/rookies/split/{year:int}")]
        public IActionResult GetMemberByYear(int year)
        {
            var result = from person in list
                         group person by person.dob.Year.CompareTo(year) into grp
                         select new
                         {
                             Key = grp.Key switch
                             {
                                 -1 => $"Birth year less than {year}",
                                 0 => $"Birth year equals to {year}",
                                 1 => $"Birth year more than {year}",
                                 _ => string.Empty
                             },
                             Data = grp.ToList()
                         };

            return Json(result);
        }
        [Route("NashTech/rookies/export")]
        public IActionResult GetExcel()
        {
            var persons = (from student in list
                           select student).ToList();
            var buffer = WriteCsvToMemory(persons);
            var memoryStream = new MemoryStream(buffer);
            return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "people.csv" };
        }
        public byte[] WriteCsvToMemory(List<Person> data)
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(data);
                writer.Flush();
                return stream.ToArray();
            }
        }
    }
}