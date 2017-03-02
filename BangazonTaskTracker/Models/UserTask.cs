﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BangazonTaskTracker.DAL;

namespace BangazonTaskTracker.Models
{
    public class UserTask : IDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public TaskStatus Status { get; set; }
        public DateTime? CompletedOn { get; set; }
    }
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Complete
    }
}