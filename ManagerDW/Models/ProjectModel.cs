using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerDW.Models
{
    public class ProjectModel
    {
        public Guid Id { get; set; }
        public string NameProject {get;set;}
        public string Description { get; set; }
        public string LinkForDemo { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int ProcentSuccess { get; set; }
    }
}
