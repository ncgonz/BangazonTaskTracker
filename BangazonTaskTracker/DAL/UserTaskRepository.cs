using BangazonTaskTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BangazonTaskTracker.DAL
{
    public class UserTaskRepository
    {
        UserTaskContext Context { get; set; }

        public List<UserTask> ListOfTasks { get; private set; }

        public UserTaskRepository()
        {
            Context = new UserTaskContext();
        }
        public UserTaskRepository(UserTaskContext _context)
        {
            Context = _context;
        }
        //ADD USERTASK TO DB
        public void AddUserTask(UserTask _userTask)
        {
            Context.UserTasks.Add(_userTask);
            Context.SaveChanges();
        }
        public void AddUserTaskById(int id)
        {
            Context.UserTasks.Add(id);
            Context.SaveChanges();    
        }
       //REMOVE USERTASK FROM DB
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
        public UserTask UpdateUserTaskById(int id, UserTask userTask)
        {
            Context.Entry.Update(id, userTask);
                return userTask;
        }


        //get all UserTasks
        public List<UserTask> Get()
        {
            return ListOfTasks;
        }
    }
}