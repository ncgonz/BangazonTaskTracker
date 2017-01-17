using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangazonTaskTracker.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CompletedOn { get; set; }
    }
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Complete
    }
}