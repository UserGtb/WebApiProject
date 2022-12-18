using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Access;
using Microsoft.EntityFrameworkCore;
using Project.App;
using Xunit;

namespace TestProject.ProjectTest
{
    public class DeleteProject : TestContext
    {
       
        [Fact]
        public async ValueTask DeleteProjectTest()
        {
            var testproj = await _dbcontext.ProjectsApp.SingleOrDefaultAsync(proj => proj.ID == DBContextTestInit.ProjectUpdateID);
            _dbcontext.ProjectsApp.Remove(testproj);
            await _dbcontext.SaveChangesAsync();
            Assert.Null(await _dbcontext.ProjectsApp.SingleOrDefaultAsync(proj => proj.ID == DBContextTestInit.ProjectUpdateID));
        }
    }
}
