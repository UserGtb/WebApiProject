using System;
using System.Collections.Generic;
using System.Text;
using Data.Access;
using Project.App;

namespace TestProject
{
    public abstract class TestContext : IDisposable
    {
        protected ProjectAppDBcontext _dbcontext;


        public TestContext()
        {
            _dbcontext = DBContextTestInit.Create();
        }

        public void Dispose()
        {
            DBContextTestInit.Destroy(_dbcontext);
        }
    }
}
