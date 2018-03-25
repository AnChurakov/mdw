using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMDW.Models;

namespace WebMDW.Models.Priority
{
    public class PriorityModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Task.TaskModel> Tasks { get; set; }
        
    }
}