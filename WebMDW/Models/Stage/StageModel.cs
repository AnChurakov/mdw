using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMDW.Models.Stage
{
    public class StageModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Project.ProjectModel> Projects { get; set; }
    }
}