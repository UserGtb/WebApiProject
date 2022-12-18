using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Task.App;
using Xunit;

namespace TestProject.TaskTest
{
    public class CreateTask : TestContext
    {
        [Fact]
        public async ValueTask CreateTaskTest()
        {
            var testtask = new TaskAppStored {
                ID = DBContextTestInit.TaskCreateID,
                name = "tasktest",
                description = "test",
                priority = 0,
                status = DBContextTestInit.ProjectUpdateID.ToString(),
                ProjectAppStoredID = DBContextTestInit.ProjectCreateID
            };
            _dbcontext.TasksApp.Add(testtask);
            await _dbcontext.SaveChangesAsync();
            Assert.NotNull(_dbcontext.TasksApp.SingleOrDefaultAsync(tsk => tsk.ID == DBContextTestInit.TaskCreateID));
        }
    }
}
