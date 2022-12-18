using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Access;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.App;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ProjectAppDBcontext _context;

        public TaskController(ProjectAppDBcontext context)
        {
            _context = context;
        }

        private string GetTaskStatus(int stat)
        {
            string current_stat = stat == 0 ? Task.App.status.ToDo.ToString() : stat == 1
                                            ? Task.App.status.InProgress.ToString() : Task.App.status.Done.ToString();
            return current_stat;

        }
        [HttpGet]
        public async Task<ActionResult<TaskAppStored>> GetAllTasks()
        {
            return Ok(await _context.TasksApp.ToListAsync());
        }
        [HttpPost("ProjectID, name, status, priority, description")]
        public async Task<ActionResult<TaskAppStored>> CreateTask(Guid ProjectID, string name, int priority, string description, int stat = 0)
        {
            var taskapp = new TaskAppStored {

                ID = Guid.NewGuid(),
                name = name,
                status = GetTaskStatus(stat),
                description = description,
                priority = priority,
                ProjectAppStoredID = ProjectID,
            };

            var projs = _context.ProjectsApp.SingleOrDefault(proj => proj.ID == ProjectID);

            if (projs == null) {

                return NotFound();
            }
            _context.TasksApp.Add(taskapp);
            await _context.SaveChangesAsync();
            return Ok(taskapp);
        }

        [HttpPut("id, name, status, priority, description")]
        public async Task<ActionResult<TaskAppStored>> UpdateTask(Guid id, string name, int priority, string description, int stat = 0)
        {
            var taskapp =  _context.TasksApp.SingleOrDefault(tsk => tsk.ID == id);
            if (taskapp == null) {

                return NotFound();
            }
            taskapp.name = name;
            taskapp.priority = priority;
            taskapp.description = description;
            taskapp.status = GetTaskStatus(stat);
            await _context.SaveChangesAsync();
            return Ok(taskapp);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<TaskAppStored>> DeleteTask(Guid id)
        {
            var taskapp = _context.TasksApp.SingleOrDefault(tsk => tsk.ID == id);
            if (taskapp == null) {
                return NotFound();
            }
            _context.TasksApp.Remove(taskapp);
            await _context.SaveChangesAsync();
            return Ok(await _context.TasksApp.ToListAsync());
        }
    }
}
