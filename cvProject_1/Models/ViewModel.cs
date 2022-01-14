using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace cvProject_1.Models;
public class ViewModel
    {
        public Project Proj { get; set; }
        public _Task Task { get; set; }

        public ViewModel()
        {
            this.Proj = new Project();
            this.Task = new _Task();
        }
    }