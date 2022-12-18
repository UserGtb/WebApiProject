using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.TaskTest
{
    public class UpdateTask : TestContext
    {
        [Fact]
        public async ValueTask UpdateTaskTest()
        {
            Guid newID = DBContextTestInit.TaskUpdateID;
            var testtask = await _dbcontext.TasksApp.FirstOrDefaultAsync(tsk => tsk.ID == DBContextTestInit.TaskCreateID);
            testtask.ID = DBContextTestInit.TaskUpdateID;
            await _dbcontext.SaveChangesAsync();
            Assert.NotNull(await _dbcontext.ProjectsApp.SingleOrDefaultAsync(tsk => tsk.ID == newID));

        }
    }
}
