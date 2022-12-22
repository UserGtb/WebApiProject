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

        //Static fields that will be use in testing project
        public static Guid ProjectCreateID = Guid.NewGuid();
        public static Guid ProjectUpdateID = Guid.NewGuid();

        //Static fields that will be use in testing task
        public static Guid TaskCreateID = Guid.NewGuid();
        public static Guid TaskUpdateID = Guid.NewGuid();

        //Creating a test context of the database
        public static ProjectAppDBcontext Create()
        {
            var options = new DbContextOptionsBuilder<ProjectAppDBcontext>().UseInMemoryDatabase("webapiprojectdb").Options;
            var context = new ProjectAppDBcontext(options);
            context.Database.EnsureCreated();
            context.SaveChanges();
            return context;
        }

        //Destroying a test context of the database
        public static void Destroy(ProjectAppDBcontext dBcontext)
        {
            dBcontext.Database.EnsureDeleted();
            dBcontext.Dispose();
        }
    }
}
