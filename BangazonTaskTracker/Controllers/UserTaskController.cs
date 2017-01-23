using BangazonTaskTracker.DAL;
using BangazonTaskTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BangazonTaskTracker.Controllers
{
    public class UserTaskController : ApiController
    {
        UserTaskRepository Repo = new UserTaskRepository();
        UserTaskContext Context { get; set; }

        

        // GET api/<controller>
        public List<UserTask> Get()
        {
            var currentUser = User.Identity.Name;
            //need this for list of tasks for speci users
            var currentUserActivities = Repo.Get();
            return currentUserActivities;
        }

        // GET api/<controller>/5
        public UserTask Get(int userTaskId)
        {
            return Repo.GetUserTaskById(userTaskId);
        }

        // POST api/<controller>
        public void Post(UserTask userTask)
        {
            var currentUser = User.Identity.Name;
            userTask.Name = currentUser;
            Repo.AddUserTask(userTask);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]UserTask value)
        {
            var foundUserTaskForUpdate = Repo.GetUserTaskById(id);
            Repo.UpdateUserTaskById(id, value);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(UserTask _userTask)
        {
            Context.UserTasks.Remove(_userTask);
            Context.SaveChanges();
        }
    }
}