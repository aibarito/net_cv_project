using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace cvProject_1.Models;

public class _Task
{
    public enum _status{
        ToDo = 1,
        InProgress = 2,
        Done = 3
    }
    [Key]
    [Range(0,0, ErrorMessage="Do not modify the id field, leave it as 0")]    

    public int Id {get; set;}
    [Required(ErrorMessage = "Name field is Required")]
    public string Name{get;set;} = string.Empty;
    [Required(ErrorMessage = "Description is Required")]
    
    public string Description{get; set;} = string.Empty;
    [Required(ErrorMessage = "Status is Required")]
    [Range(1,3, ErrorMessage="Enter as an integer: 1 - ToDo, 2 - InProgress, 3 - Done")]
    public _status Status{get;set;}= _status.ToDo;
    [Required(ErrorMessage = "Priority is Required")]
    [Range(0, 100,ErrorMessage = "Priority must be from 0 (low) to 100 (high)")]
    public int Priority{get; set;}
    [Required(ErrorMessage = "Project Id is Required")]
    public int ProjectId{get;set;}
        // public List<Task> Tasks {get; set;}
}