using System;
using System.Collections.Generic;
using System.Text;
using Task.App;

namespace Project.App
{
    /// <summary>
    /// Defining field properties for the ProjectApp class
    /// </summary>
    public class ProjectApp
    {
        public Guid ID { get; set; }
        public string name { get; set; }
        public IList<TaskAppStored> task { get; set; }
       
    }
}
