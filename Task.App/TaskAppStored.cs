using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Task.App
{
    public enum status { ToDo, InProgress, Done }

    // Defining field properties for the TaskAppStored class
    public class TaskAppStored : TaskApp
    {
        public string status { get; set; }
        public int priority { get; set; }
        [ForeignKey("ProjectAppStoredID")]
        public Guid ProjectAppStoredID { get; set; }
    }
}
