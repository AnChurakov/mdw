using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerDW.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Create { get; set; }
        public DateTime Complete { get; set; }
    }
}
