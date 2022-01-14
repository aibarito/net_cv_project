using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using cvProject_1.Models;
using cvProject_1.Data;
using Microsoft.EntityFrameworkCore;

namespace cvProject_1.Controllers;
[Route("api/[controller]")]
public class ProjectController : CommonController
{

    private readonly ApplicationDbContext _context;
    public ProjectController(ApplicationDbContext context)
    {
        _context=context;
    }
    //GET
    //Lists all projects
    [HttpGet]

    public async Task<ActionResult<List<Project>>> List()
    {
        return Ok(await _context.myProjects.ToListAsync());
    }
    
    // POST
    // Send post query
    [HttpPost]
    public async Task<ActionResult<List<Project>>> Create(Project proj)
    {
        if(proj == null){
            return NotFound("Enter proper project");
        }
        if(proj.EndDate < proj.StartDate){
            ModelState.AddModelError("startDate", "The end date of project must be after the starting date (Not specified date returns a current time)");
            return BadRequest("The end date of project must be after the starting date (Not specified date returns a current time)");
        }
        if(ModelState.IsValid){
            _context.myProjects.Add(proj);
            await _context.SaveChangesAsync();
            return Ok(await _context.myProjects.ToListAsync());
        }else{
            return BadRequest();
        }
    }
  
    //POST
    //Send update query
    [HttpPut("{id}")]
     public async Task<ActionResult<List<Project>>> Edit(int? id, Project proj)
    {
        if(id == 0 || id==null||proj == null){
            return NotFound("Project not found");
        }
        var toUpdate = _context.myProjects.Find(id);
        if(toUpdate==null){
            return NotFound("Project with specified id is not found");
        }
        if(proj.EndDate < proj.StartDate){
            ModelState.AddModelError("startDate", "The end date of project must be after the starting date (Not specified date returns a current time)");
            return BadRequest("The end date of project must be after the starting date (Not specified date returns a current time)");
        }
        if(ModelState.IsValid){
            toUpdate.Name = proj.Name;
            toUpdate.Status = proj.Status;
            toUpdate.StartDate=proj.StartDate;
            toUpdate.EndDate=proj.EndDate;
            toUpdate.Priority=proj.Priority;
            await _context.SaveChangesAsync();
            return Ok(await _context.myProjects.ToListAsync());
        }else{
            return BadRequest();
        }
        

    }

    //POST
    //Send remove query
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Project>>> Delete(int? id)
    {
        if(id == null||id==0){
            return NotFound("Project with specified id was not found");
        }
        var toDelete = _context.myProjects.Find(id);
        if(toDelete==null){
            return NotFound("Project with specified id was not found");
        }
        foreach(_Task task in _context.myTasks){
            if(task.ProjectId == id){
                _context.myTasks.Remove(task);
            }
        }
        _context.myProjects.Remove(toDelete);
        await _context.SaveChangesAsync();
        return Ok(await _context.myProjects.ToListAsync());
    }
}
