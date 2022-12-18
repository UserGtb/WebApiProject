using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Access
{
    public class DBInitialize
    {
        public static void Initialize(ProjectAppDBcontext projectAppDBcontext)
        {
            projectAppDBcontext.Database.EnsureCreated();
        }
    }
}
