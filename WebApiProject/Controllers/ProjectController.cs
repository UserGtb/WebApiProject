using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.App;
using Project.App;
using Data.Access;
using Microsoft.EntityFrameworkCore;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        //private static List<ProjectApp> newproj = new List<ProjectApp>(new[] { new ProjectApp() { ID = Guid.NewGuid(), name="test", startdate=DateTime.Now.Date, completiondate = DateTime.Now.Date, task = new List<TaskApp>() } });

        private readonly ProjectAppDBcontext _context;
      
        public ProjectController(ProjectAppDBcontext context)
        {
            _context = context;
        }

        private string GetProjStatus(int stat)
        {
            string current_stat = stat == 0 ? Project.App.status.NotStarted.ToString() : stat == 1
                                            ? Project.App.status.Active.ToString() : Project.App.status.Completed.ToString();
            return current_stat;

        }

        /// <summary>
        /// View all projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ProjectAppStored>> GetAllProjects()
        {
            return Ok(await _context.ProjectsApp.ToListAsync());
        }
        /// <summary>
        /// View all tasks in the project
        /// </summary>
        /// <returns></returns>
        [HttpGet("ProjID")]
        public async Task<ActionResult<ProjectAppStored>> GetAllTask(Guid id)
        {
            var proj = _context.ProjectsApp.Find(id);
            if (proj == null)
                return NotFound();
            var taskapplist = await _context.TasksApp.Where(tsk => tsk.ProjectAppStoredID == proj.ID).ToListAsync();
            return Ok(taskapplist);
        }

        //[HttpGet]
        //public async Task<IEnumerable<ProjectApp>> GetTest() => newproj;

        /// <summary>
        /// Create project with various fields
        /// </summary>
        /// <returns></returns>
        [HttpPost("name, completiondate, status, priority")]
        public async Task<IActionResult> CreateProj(string n, string endDate, int priority, int stat = 0)
        {
            var projectapp = new ProjectAppStored {
                ID = Guid.NewGuid(),
                name = n,
                startdate = DateTime.Now.Date,
                completiondate = DateTime.Parse(endDate),
                priority = priority,
                task = new List<TaskAppStored>(),
                status = GetProjStatus(stat),
            };
            _context.ProjectsApp.Add(projectapp);
            await _context.SaveChangesAsync();
            //newproj.Add(projectapp);
            //await _context.ProjectsApp.ToListAsync();
            return Ok(projectapp);
        }

        /// <summary>
        /// Edit project fields
        /// </summary>
        /// <returns></returns>
        [HttpPut("id, name, completiondate, status, priority")]
        public async Task<IActionResult> UpdateProj(Guid id, string n, string endDate, int priority, int stat = 0)
        {
            var currentProj = await _context.ProjectsApp.FirstOrDefaultAsync(proj => proj.ID == id);
            if (currentProj == null) {
                return NotFound();
            }
            currentProj.name = n;
            currentProj.completiondate = DateTime.Parse(endDate);
            currentProj.priority = priority;
            currentProj.status = GetProjStatus(stat);
            await _context.SaveChangesAsync();
            return Ok(currentProj);
        }

        /// <summary>
        /// Delete project from Database and its tasks
        /// </summary>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProj(Guid id)
        {
            var currentProj = await _context.ProjectsApp.FindAsync(id);
            if (currentProj == null)
                return NotFound();
            var taskscurrentProj = await _context.TasksApp.Where(tsk=>tsk.ProjectAppStoredID==id).ToListAsync();
            _context.TasksApp.RemoveRange(taskscurrentProj);
            _context.ProjectsApp.Remove(currentProj);
            await _context.SaveChangesAsync();
            return Ok(await _context.ProjectsApp.ToListAsync());
        }


    }
}
