using System;
using System.Collections.Generic;
using Data.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Project.App;
using Xunit;

namespace TestProject
{
    public class DBContextTestInit
    {
        public static IConfiguration Configuration { get; }

        public static Guid ProjectCreateID = Guid.NewGuid();
        public static Guid ProjectUpdateID = Guid.NewGuid();

        public static Guid TaskCreateID = Guid.NewGuid();
        public static Guid TaskUpdateID = Guid.NewGuid();
        public static ProjectAppDBcontext Create()
        {
            var options = new DbContextOptionsBuilder<ProjectAppDBcontext>().UseInMemoryDatabase("webapiprojectdb").Options;
            var context = new ProjectAppDBcontext(options);
            context.Database.EnsureCreated();
            //context.ProjectsApp.AddRange(
            //    new ProjectAppStored {
            //        ID = ProjectUpdateID,
            //        name = "newTestProj",
            //        startdate = DateTime.Now,
            //        completiondate = DateTime.Now.AddDays(5),
            //        status = "NoStarted",
            //        priority = 0,
            //        task = null
            //    }
            //    );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(ProjectAppDBcontext dBcontext)
        {
            dBcontext.Database.EnsureDeleted();
            dBcontext.Dispose();
        }
    }
}
