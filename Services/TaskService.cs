using System;
using System.Collections.Generic;
using System.Linq;
using Trello.DataAccess;
using Trello.Interfaces;
using Trello.Models;

namespace Trello.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;
        public TaskService(ApplicationDbContext context)
        {
            context = _context;
        }
        public bool CreateTask(Task task)
        {

            if (task != null)
            {
                _context.Tasks.Add(task);
                return true;
            }
            return false;
        }

        public Task GetTask(int taskId)
        {

            var taskData = _context.Tasks.SingleOrDefault(t => t.Id == taskId);
            if (taskData.Id == 0)
                throw new ArgumentNullException($"Task id is not nullable");
            return taskData;
        }

        public bool UpdateTask(Task task)
        {
            if (task != null)
            {
                var taskData = _context.Tasks.SingleOrDefault(t => t.Id == task.Id);
                if (taskData != null)
                {
                    taskData.Title = task.Title;
                    _context.Tasks.Update(taskData);
                }
                return true;
            }
            return false;
        }
    }
}
