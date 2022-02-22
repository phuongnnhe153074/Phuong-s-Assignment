using Assignment_Entity_1.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace Assignment_Entity_1.Data;


public class MyDbContext : DbContext{
    public MyDbContext(DbContextOptions<MyDbContext> options): base(options){

    }
    public virtual DbSet<Student>? Students {get;set;}
}