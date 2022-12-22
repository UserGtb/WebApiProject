using System;
using System.Collections.Generic;
using System.Text;
using Data.Access;
using Project.App;

namespace TestProject
{
    public abstract class TestContext : IDisposable
    {
        //Defining a field for test database context
        protected ProjectAppDBcontext _dbcontext;

        //Initializing the test database context inside the constructor
        public TestContext()
        {
            _dbcontext = DBContextTestInit.Create();
        }

        //Cleaning the test database from memory
        public void Dispose()
        {
            DBContextTestInit.Destroy(_dbcontext);
        }
    }
}
