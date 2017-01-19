using BangazonTaskTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangazonTaskTracker.DAL
{
    public class UserTaskRepository
    {
        UserTaskContext Context { get; set; }
        public UserTaskRepository()
        {
            Context = new UserTaskContext();
        }
        public UserTaskRepository(UserTaskContext _context)
        {
            Context = _context;
        }
        public void AddUserTask(UserTask _userTask)
        {
            Context.UserTasks.Add(_userTask);
            Context.SaveChanges();
        }
        public void RemoveUserTask(UserTask _userTask)
        {
            Context.UserTasks.Remove(_userTask);
            Context.SaveChanges();
        }
        public UserTask GetUserTaskById(int userTaskId)
        {
            UserTask found_userTask = Context.UserTasks.FirstOrDefault(i => i.Id == userTaskId);
            if (found_userTask != null)
            {
                return found_userTask;
            }
            else
            {
                return null;
            }

        }
        //update/Edit
        //
    }
}