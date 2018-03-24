using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerDW.Models
{
    public class StageModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProjectModel> Project { get; set; }
    }
}
