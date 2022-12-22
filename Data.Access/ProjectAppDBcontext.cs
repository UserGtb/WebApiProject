using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project.App;
using Task.App;
using Data.Access.EFConfiguration;

namespace Data.Access
{
    public class ProjectAppDBcontext : DbContext
    {
        //Define the ProjectsApp entity
        public DbSet<ProjectAppStored> ProjectsApp { get; set; }

        //Define the TasksApp entity
        public DbSet<TaskAppStored> TasksApp { get; set; }

        //Define DbContextOptions parameters inside the constructor ProjectAppDBcontext class 
        public ProjectAppDBcontext(DbContextOptions<ProjectAppDBcontext> options): base(options) { }

        //Define configuration in the method OnModelCreating for the entity model database
        protected override void OnModelCreating (ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProjectConfiguration());
            base.OnModelCreating(builder);
        }
       

    }
}
