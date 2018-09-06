using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using managerdw.Models;
using managerdw.Controllers;
using System.Threading.Tasks;
using System.Data.Entity;

namespace managerdw.Controllers
{
    public class ProjectController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();


        [Authorize]
        public ActionResult MyProject()
        {

            var select = dbContext.Projects.Include(a => a.Users).ToList();

            return View(select);
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(dbContext.Projects.OrderByDescending(a => a.DateCreate).ToList());
        }


        [Authorize]
        public ActionResult Single(Guid Id)
        {
            ViewBag.Tasks = dbContext.Tasks.Where(a => a.Project.Id == Id).OrderByDescending(t => t.Create).Take(5).ToList();

            var completed = dbContext.Tasks.Where(a => a.Stages.Name == "Разработка дизайна" && a.Status.Name == "Выполнен" && a.Project.Id == Id).Count();

            var total = dbContext.Tasks.Where(a => a.Stages.Name == "Разработка дизайна" && a.Project.Id == Id).Count();

            ViewBag.Design = Procent(total, completed);

            var completedDevelop = dbContext.Tasks.Where(a => a.Stages.Name == "Разработка функционала" && a.Status.Name == "Выполнен" && a.Project.Id == Id).Count();

            var totalDevelop = dbContext.Tasks.Where(a => a.Stages.Name == "Разработка функционала" && a.Project.Id == Id).Count();

            ViewBag.Develop = Procent(totalDevelop, completedDevelop);

            var completedAnalyze = dbContext.Tasks.Where(a => a.Stages.Name == "Анализ требований" && a.Status.Name == "Выполнен" && a.Project.Id == Id).Count();

            var totalAnalyze = dbContext.Tasks.Where(a => a.Stages.Name == "Анализ требований" && a.Project.Id == Id).Count();

            ViewBag.Analyze = Procent(totalAnalyze, completedAnalyze);

            var completedTesting = dbContext.Tasks.Where(a => a.Stages.Name == "Тестирование" && a.Status.Name == "Выполнен" && a.Project.Id == Id).Count();

            var totalTesting = dbContext.Tasks.Where(a => a.Stages.Name == "Тестирование" && a.Project.Id == Id).Count();

            ViewBag.Testing = Procent(totalTesting, completedTesting);

            return View(dbContext.Projects.FirstOrDefault(a => a.Id == Id));
        }

        [Authorize]
        public int Procent(int total, int completed)
        {
            var result = 0;

            if (total != 0)
            {
                 result = (completed * 100) / total;
            }
            else if(total == 0)
            {
                result = 0;
            }
            else if(completed == total)
            {
                result = 100;
            }

            return result;
        }

        [Authorize]
        public ActionResult AddUser(Guid ProjectId)
        {
            ViewBag.ProjectId = ProjectId;

            ViewBag.Users = dbContext.Users.ToList();

            return View();
        }

        [Authorize]
        [HttpPost]
        public RedirectToRouteResult AddUserInProject(Guid ProjectId, string User)
        {
            var user = dbContext.Users.FirstOrDefault(a => a.Id == User);

            var project = dbContext.Projects.FirstOrDefault(a => a.Id == ProjectId);

            if (user != null && project != null)
            {
                project.Users = new List<ApplicationUser> { user };

                dbContext.SaveChanges();
            }

            return RedirectToAction("AddUser", new { ProjectId = ProjectId});
        }

        [Authorize]
        public ActionResult AddPage()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public RedirectToRouteResult Create(string Name, string Description, string DateComplete, string Price)
        {
            var splitDate = DateComplete.Split('/');
            var newDate = String.Format("{0}.{1}.{2}", splitDate[1], splitDate[0], splitDate[2]);


            if (Name != null && Description != null && Price != null)
            {
                Project pr = new Project
                {
                    Id = Guid.NewGuid(),
                    Name = Name,
                    Description = Description,
                    DateCreate = DateTime.Now,
                    DateComplete = DateTime.Parse(newDate),
                    Price = Price,
                    Stages = GetStage("Анализ требований"),
                    Status = GetStatus("В работе")
                                     
                    
                };

                dbContext.Projects.Add(pr);

                dbContext.SaveChanges();
                
            }

            return RedirectToAction("AddPage");
        }

        [Authorize]
        public Stage GetStage(string name)
        {
            return dbContext.Stages.FirstOrDefault(a => a.Name == name);
        }

        [Authorize]
        public Status GetStatus(string name)
        {
            return dbContext.Status.FirstOrDefault(a => a.Name == name);
        }

        [Authorize]
        public ActionResult Edit(Guid Id)
        {
            ViewBag.Stage = dbContext.Stages.ToList();

            ViewBag.Status = dbContext.Status.ToList();

            return View(dbContext.Projects.FirstOrDefault(a => a.Id == Id));
        }


        [Authorize]
        [HttpPost]
        public string UpdateMainInfo(Guid ProjectId, string name, string desc, string date, string price)
        {
            var newDate = date;

            if (name != null && desc != null && date != null && price != null)
            {
                var splitDate = date.Split('/');

                if (splitDate.Count() > 1)
                {
                    newDate =  String.Format("{0}.{1}.{2}", splitDate[1], splitDate[0], splitDate[2]);
                }

                var project = dbContext.Projects.FirstOrDefault(a => a.Id == ProjectId);

                project.Name = name;
                project.Description = desc;
                project.Price = price;
                project.DateComplete = DateTime.Parse(newDate);

                dbContext.SaveChanges();

                return "true";
            }

            return "false";
        }

        [Authorize]
        [HttpPost]
        public string UpdateStage(Guid StageId, Guid ProjectId)
        {
            var stage = dbContext.Stages.FirstOrDefault(a => a.Id == StageId);

            var project = dbContext.Projects.FirstOrDefault(a => a.Id == ProjectId);

            if (stage != null && project != null)
            {
                project.Stages = stage;

                dbContext.SaveChanges();

                return "true";
            }

            return "false";
        }

        [Authorize]
        [HttpPost]
        public string UpdateStatus(Guid StatusId, Guid ProjectId)
        {
            var status = dbContext.Status.FirstOrDefault(a => a.Id == StatusId);

            var project = dbContext.Projects.FirstOrDefault(a => a.Id == ProjectId);

            if (status != null && project != null)
            {
                project.Status = status;

                dbContext.SaveChanges();

                return "true";
            }

            return "false";
        }

        [Authorize]
        [HttpGet]
        public RedirectToRouteResult Delete(Guid Id)
        {
            var select = dbContext.Projects.FirstOrDefault(a => a.Id == Id);

            var selectTasksProject = dbContext.Tasks.Where(a => a.Project.Id == Id).ToList();

            if (select != null)
            {
                foreach(var task in selectTasksProject)
                {
                    dbContext.Tasks.Remove(task);
                }

                dbContext.Projects.Remove(select);
 
                dbContext.SaveChanges();

            }

            return RedirectToAction("Index");
        }
    }
}