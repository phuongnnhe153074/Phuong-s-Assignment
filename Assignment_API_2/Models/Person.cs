namespace Assignment_API_2.Models;
public class Person : PersonCreateModel
{
    public string? fullname { get; set; }


}
public class PersonUpdateModel:PersonCreateModel
{public int Index{get;set;}}
public class PersonCreateModel
{
    public string? firstname { get; set; }
    public string? lastname { get; set; }
    public string? gender { get; set; }
    public int? age { get; set; }
    public string? address { get; set; }


}