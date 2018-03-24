using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerDW.Models
{
    public class ProjectModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Название проекта")]
        public string NameProject {get;set;}

        [Required]
        [Display(Name = "Описание проекта")]
        public string Description { get; set; }
        public string LinkForDemo { get; set; }

        [Required]
        [Display(Name = "Дата начала проекта")]
        public DateTime DateBegin { get; set; }

        [Required]
        [Display(Name = "Дата заверешения проекта")]
        public DateTime DateEnd { get; set; }
        public int ProcentSuccess { get; set; }
        public StageModel Stage { get; set; }
        public StatusModel Status { get; set; }
    }
}
