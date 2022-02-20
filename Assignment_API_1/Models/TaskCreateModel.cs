using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Assignment_API_1.Models;
public class TaskCreateModel
{
    [Required, MaxLength(50)]
public string? Title {get;set;}
public string? Description {get;set;}

}