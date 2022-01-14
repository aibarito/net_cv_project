using Microsoft.EntityFrameworkCore;
using cvProject_1.Models;

namespace cvProject_1.Data;

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    public DbSet<Project> myProjects{get;set;}
    public DbSet<_Task> myTasks{get; set;}
}