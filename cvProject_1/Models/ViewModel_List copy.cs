using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace cvProject_1.Models;
public class ViewModel_List
    {
        public Project Proj { get; set; }
        public List<_Task> Tasks { get; set; }

        public ViewModel_List()
        {
            this.Proj = new Project();
            this.Tasks = new List<_Task>();
        }
    }