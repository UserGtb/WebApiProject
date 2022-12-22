using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Access
{
    public class DBInitialize
    {
        /// <summary>
        /// Method for creating a database in the current context
        /// </summary>
        /// <param name="projectAppDBcontext"></param>
        public static void Initialize(ProjectAppDBcontext projectAppDBcontext)
        {
            projectAppDBcontext.Database.EnsureCreated();
        }
    }
}
