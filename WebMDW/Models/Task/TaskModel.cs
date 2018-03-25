using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMDW.Models;

namespace WebMDW.Models.Task
{
    public class TaskModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateBegin { get; set; }

        public DateTime DateEnd { get; set; }

        public Priority.PriorityModel Priority { get; set; }
    }
}