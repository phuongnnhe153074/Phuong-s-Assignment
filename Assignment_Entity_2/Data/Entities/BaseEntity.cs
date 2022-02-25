using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Entity_2.Data.Entities;
public class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime? CreateTime {get;set;}
    public string? Create {get;set;}
    public string? Creator {get;set;}
    public DateTime? ModifiedTime {get;set;}
    public string? Modifier{get;set;}
}