using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace cvProject_2.Models;

public class _Task
{
    public enum status{
        ToDo = 1,
        InProgress = 2,
        Done = 3
    }
    [Key]
    public int Id {get; set;}
    [Required]
    public string Name{get;set;} = string.Empty;
    [Required]
    
    public string Description{get; set;}= string.Empty;
    [Range(1,3, ErrorMessage="Enter as an integer: 1 - ToDo, 2 - InProgress, 3 - Done")]
    public status Status{get;set;}= status.ToDo;
    [Range(0, 100,ErrorMessage = "Priority must be from 0 (low) to 100 (high)")]
    public int Priority{get; set;}
    [Required]
    public int ProjectId{get;set;}
        // public List<Task> Tasks {get; set;}
}