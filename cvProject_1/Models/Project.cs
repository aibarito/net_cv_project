using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace cvProject_1.Models;

public class Project
{
    public enum status{
        NotStarted= 1,
        Active= 2,
        Completed=3
    }

    [Key]
    [Range(0,0, ErrorMessage="Do not modify the id field, leave it as 0")]    
    public  int Id {get; set;}
    [Required(ErrorMessage = "Name field is Required")]
    public string Name{get;set;}= string.Empty;
    [Required(ErrorMessage = "Start date field is Required")]
    [DisplayName("Start Date")]
    [DataType(DataType.DateTime, ErrorMessage = "Input as a proper date")]
    public DateTime StartDate{get; set;}=DateTime.Now;
    [Required(ErrorMessage = "End Date field is Required")]
    [DisplayName("End Date")]
    [DataType(DataType.DateTime, ErrorMessage = "Input as a proper date")]
    public DateTime EndDate{get; set;} = DateTime.Now;
    // public status CurrentStatus{get; set;}
    [Required(ErrorMessage = "Status is Required")]
    [Range(1,3, ErrorMessage="Enter as an integer: 1 - Not Started, 2 - Active, 3 - Completed")]
    public status Status{get;set;} = status.NotStarted;
    
    [Required(ErrorMessage = "Priority is Required")]
    [Range(0, 100,ErrorMessage = "Priority must be from 0 (low) to 100 (high)")]
    public int Priority{get; set;}
        // public List<Task> Tasks {get; set;}
}