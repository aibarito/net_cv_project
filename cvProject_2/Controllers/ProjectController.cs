using Microsoft.AspNetCore.Mvc;
using cvProject_2.Models;
using cvProject_2.Data;

namespace cvProject_2.Controllers;

public class ProjectController : Controller
{

    private readonly ApplicationDbContext _context;
    public ProjectController(ApplicationDbContext context)
    {
        _context=context;
    }
    //GET
    //Lists all projects
    public IActionResult Index()
    {
        IEnumerable<Project> projects = _context.myProjects;
        return View(projects);
    }
    //GET 
    //Creates a project
    public IActionResult Create()
    {
        return View();
    }
    //POST
    //Send post query
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Project proj)
    {
        if(proj.EndDate < proj.StartDate){
            ModelState.AddModelError("startdate", "The end date of project must be after the starting date");
        }
        if(ModelState.IsValid){
            _context.myProjects.Add(proj);
            _context.SaveChanges();
            TempData["success"]="Project created successfully";
            return RedirectToAction("Index");
        }
        return View(proj);
    }
    //GET
    //Edit a project
    public IActionResult Edit(int? id)
    {
        if(id == null||id==0){
            return NotFound();
        }
        var proj = _context.myProjects.Find(id);
        if(proj==null){
            return NotFound();
        }
        return View(proj);
    }
    //POST
    //Send update query
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Project proj)
    {
        if(proj.EndDate < proj.StartDate){
            ModelState.AddModelError("startdate", "The end date of project must be after the starting date");
        }
        if(ModelState.IsValid){
            _context.myProjects.Update(proj);
            _context.SaveChanges();
            TempData["success"]="Project updated successfully";
            return RedirectToAction("Index");
        }
        return View(proj);
    }
    //GET
    //Delete a project
    public IActionResult Delete(int? id)
    {
        if(id == null||id==0){
            return NotFound();
        }
        var proj = _context.myProjects.Find(id);
        if(proj==null){
            return NotFound();
        }
        return View(proj);
    }

    //POST
    //Send remove query
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Project proj)
    {
        var toDelete = _context.myProjects.Find(proj.Id);
        if(toDelete==null){
            return NotFound();
        }
        foreach(_Task task in _context.myTasks){
            if(task.ProjectId == proj.Id){
                _context.myTasks.Remove(task);
            }
        }
        _context.myProjects.Remove(toDelete);
        _context.SaveChanges();
        TempData["success"]="Project deleted successfully";
        return RedirectToAction("Index");
    }
    

}
