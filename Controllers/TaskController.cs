using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cvProject_2.Models;
using cvProject_2.Data;

namespace cvProject_2.Controllers;

public class TaskController : Controller
{
    private readonly ApplicationDbContext _context;
    public TaskController(ApplicationDbContext context)
    {
        _context=context;
    }
    //GET
    //List all tasks of the project given by id
    public IActionResult Index(int? id)
    {
        if(id == null){
            return NotFound();
        }
        var proj = _context.myProjects.Find(id);
        if(proj==null){
            return NotFound();
        }
        ViewModel_List model = new ViewModel_List();
        model.Proj = proj;
        model.Tasks =_context.myTasks.ToList();
        return View(model);
    }
    //GET
    //Creates a task for project given by its id
    public IActionResult Create(int? id)
    {
        return View();
    }
    //POST
    //Sends post query to post a task
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(_Task task)
    {
        if(ModelState.IsValid){
            task.Id = 0;
            _context.myTasks.Add(task);
            _context.SaveChanges();
            TempData["success"]="Project created successfully";
            return RedirectToAction("Index", new {id =task.ProjectId});
        }
        return View(task.ProjectId);
    }
    //GET
    //Edits a task given by tasks id
    public IActionResult Edit(int? id)
    {
        if(id == null||id==0){
            return NotFound();
        }
        var task = _context.myTasks.Find(id);
        if(task==null){
            return NotFound();
        }
        return View(task);
    }
    //POST
    //Sends update query
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(_Task task)
    {
        if(ModelState.IsValid){
            _context.myTasks.Update(task);
            _context.SaveChanges();
            TempData["success"]="Project updated successfully";
            return RedirectToAction("Index", new {id =task.ProjectId});
        }
        return View(task);
    }
    //GET
    //Deletes a task given by task id
    public IActionResult Delete(int? id)
    {
        if(id == null||id==0){
            return NotFound();
        }
        var task = _context.myTasks.Find(id);
        if(task==null){
            return NotFound();
        }
        return View(task);
    }
    //POST
    //Send a remove query
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(_Task task)
    {
        var toDelete = _context.myTasks.Find(task.Id);
        if(toDelete==null){
            return NotFound();
        }
        _context.myTasks.Remove(toDelete);
        _context.SaveChanges();
        TempData["success"]="Project deleted successfully";
        return RedirectToAction("Index", new {id =task.ProjectId});
    }
    

}
