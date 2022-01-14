using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using cvProject_1.Models;
using cvProject_1.Data;
using Microsoft.EntityFrameworkCore;

namespace cvProject_1.Controllers;
[Route("api/[controller]")]
public class TaskController : CommonController
{
    private readonly ApplicationDbContext _context;
    public TaskController(ApplicationDbContext context)
    {
        _context=context;
    }
    //GET
    //List all tasks
    [HttpGet]
    public async Task<ActionResult<List<_Task>>> Index()
    {
        return (Ok(await _context.myTasks.ToListAsync()));
    }
    //GET
    //List tasks that belong to a project with id = id
    [HttpGet("{projectid}")]
    public async Task<ActionResult<List<_Task>>> Index(int? projectid)
    {
        if(projectid == null){
            return NotFound("Project with specified id is not found");
        }
        var proj = _context.myProjects.Find(projectid);
        if(proj==null){
            return NotFound("Project with specified id is not found");
        }
        return (Ok(await _context.myTasks.Where(x => x.ProjectId == projectid).ToListAsync()));
    }
    
    // POST
    // Sends post query to post a task
    // Add a new task to a project. The project id must be specified
    [HttpPost("{projectid}")]
    public async Task<ActionResult<List<_Task>>> Create(int projectid, _Task task)
    {
        if(task == null){
            return NotFound("Task cannot be added becuse it is empty");
        }
        var proj = _context.myProjects.Find(projectid);
        if(proj==null){
            return NotFound("Task cannot be added becuse project with its projectid doesnt exist");
        }
        task.ProjectId=projectid;
        _context.myTasks.Add(task);
        await _context.SaveChangesAsync();
        return (Ok(await _context.myTasks.Where(x => x.ProjectId == task.ProjectId).ToListAsync()));
   }
 
    //POST
    //Sends update query
    //The id - id of the updated task
    [HttpPut("{id}")]
    public async Task<ActionResult<List<_Task>>> Edit(int? id, _Task task)
    {
        if(task == null || id==0){
            return BadRequest("enter an existing id of the task");
        }
        
        var toUpdate = _context.myTasks.Find(id);
        if(toUpdate==null){
            return BadRequest("enter an existing id of the task");
        }
        if(task.ProjectId != toUpdate.ProjectId){
            // return BadRequest("The project id must not be updated!");
        }
        toUpdate.Name = task.Name;
        toUpdate.Status = task.Status;
        toUpdate.Priority=task.Priority;
        await _context.SaveChangesAsync();
        return (Ok(await _context.myTasks.Where(x => x.ProjectId == toUpdate.ProjectId).ToListAsync()));
    }

    //POST
    //Send a remove query
    //delete task with id = id
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<_Task>>> Delete(int? id)
    {
        
        if(id == null||id==0){
            return NotFound("id must be > 0");
        }
        var toDelete = _context.myTasks.Find(id);
        if(toDelete==null){
            return NotFound("enter an existing id of the task");
        }
        int savedId = toDelete.ProjectId;
        _context.myTasks.Remove(toDelete);
        await _context.SaveChangesAsync();
        return (Ok(await _context.myTasks.Where(x => x.ProjectId == savedId).ToListAsync()));
    }

}
