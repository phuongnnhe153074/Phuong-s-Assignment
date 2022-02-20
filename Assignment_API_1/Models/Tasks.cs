using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Assignment_API_1.Models;

public class Task : TaskUpdateModel
{
    public Guid Id {get;set;}
   

}