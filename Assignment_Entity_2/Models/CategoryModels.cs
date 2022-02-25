using System.ComponentModel.DataAnnotations;
namespace Assignment_Entity_2.Models;

public class CategoryViewModel{
public int Id {get; set;}
public string? Name {get; set;}
public IEnumerable<ProductViewModel>? products {get;set;}
}
public class CategoryCreateModel{
    [Required, MaxLength(50)]
public string? Name {get; set;}
public IEnumerable<ProductCreateModel>? products {get;set;}
}
