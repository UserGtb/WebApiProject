using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Access;
using Project.App;
using Xunit;

namespace TestProject.Project
{
    public class CreateProject : TestContext
    {
        //public static ProjectAppDBcontext _dbcontext = DBContextTestInit.Create();
        [Fact]
        public async ValueTask CreateProjectTest()
        {
            var testproj = new ProjectAppStored {
                ID = DBContextTestInit.ProjectCreateID,
                name = "testproj",
                startdate = DateTime.Now,
                completiondate = DateTime.Now.AddDays(5),
                priority = 0,
                status = "NotStarted",
            };
            _dbcontext.ProjectsApp.Add(testproj);
            await _dbcontext.SaveChangesAsync();
            Assert.NotNull(_dbcontext.ProjectsApp.SingleOrDefaultAsync(proj=> proj.ID == DBContextTestInit.ProjectCreateID));
            //_dbcontext.Database.CloseConnection();
        }

    }
}
