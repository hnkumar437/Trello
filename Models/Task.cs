using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trello.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // e.g., To Do, In Progress, Done
        public int UserId { get; set; } // Assigned user ID
    }

}
