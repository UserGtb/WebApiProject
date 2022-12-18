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
        public DbSet<ProjectAppStored> ProjectsApp { get; set; }
        
        public DbSet<TaskAppStored> TasksApp { get; set; }

        public ProjectAppDBcontext(DbContextOptions<ProjectAppDBcontext> options): base(options) { }

        protected override void OnModelCreating (ModelBuilder builder)
        {
          
            builder.ApplyConfiguration(new ProjectConfiguration());
            base.OnModelCreating(builder);
        }
       

    }
}
