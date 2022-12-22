using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Threading.Tasks;

namespace TestProject.TaskTest
{
    public class DeleteTask : TestContext
    {
        //Checking the command for delete task in the test project
        [Fact]
        public async ValueTask DeleteTaskTest()
        {
            var testtask = await _dbcontext.TasksApp.SingleOrDefaultAsync(tsk => tsk.ID == DBContextTestInit.TaskUpdateID);
            _dbcontext.TasksApp.Remove(testtask);
            await _dbcontext.SaveChangesAsync();
            Assert.Null(await _dbcontext.TasksApp.SingleOrDefaultAsync(tsk => tsk.ID == DBContextTestInit.TaskUpdateID));
        }
    }
}
