﻿using BangazonTaskTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BangazonTaskTracker.DAL
{
    public class UserTaskContext: DbContext
    {
        public virtual DbSet<UserTask> UserTasks { get; set; }
    }
}