using System;
using System.Collections.Generic;
using System.Text;
using Project.App;

namespace Project.App
{
    public enum status { NotStarted, Active, Completed }

    /// <summary>
    /// Defining field properties for the ProjectAppStored class
    /// </summary>
    public class ProjectAppStored : ProjectApp
    {
        public DateTime startdate { get; set; }
        public DateTime completiondate { get; set; }
        public string status { get; set; }
        public int priority { get; set; }
    }
}
