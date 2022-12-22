using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Access;
using Project.App;
using TestProject.ProjectTest;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TestProject.ProjectTest
{
    public class UpdateProject : TestContext
    {
        //Checking the command for update project in the test database context
        [Fact]
        public async ValueTask UpdateProjectTest()
        {
            Guid newID = DBContextTestInit.ProjectUpdateID;
            var testproj = await _dbcontext.ProjectsApp.FirstOrDefaultAsync(proj => proj.ID == DBContextTestInit.ProjectCreateID);
            testproj.ID = DBContextTestInit.ProjectUpdateID;
            await _dbcontext.SaveChangesAsync();
            Assert.NotNull(await _dbcontext.ProjectsApp.SingleOrDefaultAsync(proj => proj.ID == newID));

        }
    }
}
