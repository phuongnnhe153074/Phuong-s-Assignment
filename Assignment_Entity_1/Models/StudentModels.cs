using System.ComponentModel.DataAnnotations;
namespace Assignment_Entity_1.Models;

public class StudentViewModel{
public int Id {get; set;}

public string? FirstName {get; set;}

public string? LastName {get; set;}

public string? City {get; set;}
}
public class StudentCreateModel{
public string? FirstName {get; set;}

public string? LastName {get; set;}

public string? City {get; set;}

public string? State {get; set;}
}
