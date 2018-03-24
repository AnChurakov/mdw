using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerDW.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name =  "Название задачи")]
        public string Name { get; set; }

        [Display(Name = "Описание задачи")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Дата создания задачи")]
        public DateTime Create { get; set; }

        [Required]
        [Display(Name = "Дата завершения задачи")]
        public DateTime Complete { get; set; }

        [Required]
        [Display(Name = "Приоритет задачи")]
        public PriorityModel Priority { get; set; }
    }
}
