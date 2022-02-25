using System.ComponentModel.DataAnnotations;
namespace Assignment_Entity_2.Models;

public class ProductViewModel{
public int Id {get; set;}
public string? Name {get; set;}
public string? Manufacture {get; set;}
}
public class ProductCreateModel{
[Required, MaxLength(50)]
public string? Name {get; set;}
public string? Manufacture {get; set;}

}

