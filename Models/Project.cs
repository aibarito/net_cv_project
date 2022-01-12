using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace cvProject_2.Models;

public class Project
{
    public enum status{
        NotStarted= 1,
        Active= 2,
        Completed=3
    }

    [Key]
    public int Id {get; set;}
    [Required]
    public string Name{get;set;}= string.Empty;
    [Required]
    [DisplayName("Start Date")]
    public DateTime StartDate{get; set;}=DateTime.Now;
    [Required]
    [DisplayName("End Date")]
    public DateTime EndDate{get; set;} = DateTime.Now;
    // public status CurrentStatus{get; set;}
    [Required]
    [Range(1,3, ErrorMessage="Enter as an integer: 1 - Not Started, 2 - Active, 3 - Completed")]
    public status Status{get;set;} = status.NotStarted;
    
    [Required]
    [Range(0, 100,ErrorMessage = "Priority must be from 0 (low) to 100 (high)")]
    public int Priority{get; set;}
        // public List<Task> Tasks {get; set;}
}