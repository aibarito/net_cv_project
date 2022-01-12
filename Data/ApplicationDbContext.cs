using Microsoft.EntityFrameworkCore;
using cvProject_2.Models;

namespace cvProject_2.Data;

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    public DbSet<Project> myProjects{get;set;}
    public DbSet<_Task> myTasks{get; set;}
}