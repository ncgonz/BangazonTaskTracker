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
        //making these available in the repo
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
        //ADD USERTASK TO DB This method adds a user task to the database with the argument _userTask.
        public void AddUserTask(UserTask _userTask)
        {
            Context.UserTasks.Add(_userTask);
            Context.SaveChanges();
        }
        //ADD USERTASK TO DB BY ID This method adds a user task to the database with the argument userTaskId.
        public void AddUserTaskById(UserTask userTaskId)
        {
            Context.UserTasks.Add(userTaskId);
            Context.SaveChanges();     
        }
        //REMOVE USERTASK FROM DB This method removes a user task from the database with the argument _userTask.
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
        //update/Edit This method updates a user task to the database with the arguments id and value.
        public void UpdateUserTaskById(int id, UserTask value)
        {
            value.Id = id;
            if (value.Status == TaskStatus.Complete && !value.CompletedOn.HasValue)
            {
                value.CompletedOn = DateTime.Now;

            }
            else
            {
                Context.Entry(value).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
            }
        }

        /*get all UserTasks This method returns a list of tasks to 
          the database with the argument _taskStatus.*/
        public List<UserTask> Get(TaskStatus _taskStatus)
        {
            return ListOfTasks.Where(t => t.Status == _taskStatus).ToList();
        }
        public List<UserTask> Get()
        {
            return Context.UserTasks.ToList();
        }
    }
}