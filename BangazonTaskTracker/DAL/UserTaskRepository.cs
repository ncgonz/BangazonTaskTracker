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
        UserTaskRepository Repo = new UserTaskRepository();
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
        //ADD USERTASK TO DB BY ID
        public void AddUserTaskById(UserTask userTaskId)
        {
            Context.UserTasks.Add(userTaskId);
            Context.SaveChanges();     
        }
       //REMOVE USERTASK FROM DB
        public void RemoveUserTask(UserTask _userTask)
        {
            Context.UserTasks.Remove(_userTask);
            Context.SaveChanges();
        }
        //GET USERTASK BY USERTASKID
        public UserTask GetUserTaskById(int userTaskId)
        {
            UserTask found_userTask = Context.UserTasks.FirstOrDefault(i => i.Id == userTaskId);
            return found_userTask;    
        }
        //update/Edit
        public void UpdateUserTaskById(int id, UserTask value)
        {
            Context.Entry(value).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }
        //get all UserTasks
        public List<UserTask> Get()
        {
            return ListOfTasks;
        }
    }
}