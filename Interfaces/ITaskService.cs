using System;
using System.Collections.Generic;
using System.Linq;
using Trello.Models;

namespace Trello.Interfaces
{
    public interface ITaskService
    {
        bool CreateTask(Task task);
        Task GetTask(int taskId);
    }
}
