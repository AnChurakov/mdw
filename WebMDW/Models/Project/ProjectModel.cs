using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebMDW.Models;
using System.ComponentModel.DataAnnotations;

namespace WebMDW.Models.Project
{
    public class ProjectModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateBegin { get; set; }

        public DateTime DateEnd { get; set; }

        public string UrlProjectDemo { get; set; }

        public int ProcentComplete { get; set; }

        public Stage.StageModel Stages { get; set; }

        public virtual ICollection<ApplicationUser> User { get; set; }

    }
}