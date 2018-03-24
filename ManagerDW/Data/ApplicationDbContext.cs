using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ManagerDW.Models;

namespace ManagerDW.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ProjectModel> Projects { get; set;}
        public DbSet<Team> Teams { get; set; }
        public DbSet<StatusModel> Status { get; set; }
        public DbSet<StageModel> Stages { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<PriorityModel> Prioritys { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
