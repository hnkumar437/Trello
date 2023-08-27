using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Trello.DataAccess;
using Trello.Interfaces;
using Trello.Models;

namespace Trello.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagementController : ControllerBase
    {
        private List<Task> tasks = new List<Task>();
        private readonly ApplicationDbContext _context;
        private readonly ITaskService _taskService;
        public TaskManagementController(ApplicationDbContext context, ITaskService taskService)
        {
            context = _context;
            taskService = _taskService;
        }

        [HttpGet]
        public IActionResult GetTask(int taskId)
        {
            var task = _taskService.GetTask(taskId);
            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask(Task task)
        {
            bool hasTaskCreated = _taskService.CreateTask(task);
            if (!hasTaskCreated)
                return new EmptyResult();
            
            return Ok(task);
        }
    }
}
