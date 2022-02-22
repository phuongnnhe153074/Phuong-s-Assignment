using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Entity_1.Data.Entities;
public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
public int Id {get; set;}
[Required, MaxLength(50)]
public string? FirstName {get; set;}
[Required, MaxLength(50)]

public string? LastName {get; set;}
[ MaxLength(50)]

public string? City {get; set;}
[NotMapped]

public string? State {get; set;}


}