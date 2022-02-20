using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Assignment_API_1.Models;
public class TaskUpdateModel : TaskCreateModel
{
   [DefaultValue(0)]
 public bool Completed {get;set;}
}