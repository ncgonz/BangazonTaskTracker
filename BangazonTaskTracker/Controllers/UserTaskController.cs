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
        public HttpResponseMessage Get()
        {
            var currentUser = User.Identity.Name;
            //need this for list of tasks for specific users
            var currentUserTasks = Repo.ListOfTasks.ToList();

            if (!currentUserTasks.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);

            }else
            {
                return Request.CreateResponse(currentUserTasks);
            }
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int userTaskId)
        {
            var specificTask = Repo.GetUserTaskById(userTaskId);
            if (specificTask == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {               
                return Request.CreateResponse(specificTask);
            }
        }

        // POST api/<controller>
        public HttpResponseMessage Post(UserTask userTask)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var currentUser = User.Identity.Name;
                userTask.Name = currentUser;
                Repo.AddUserTask(userTask);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]UserTask value)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var foundUserTaskForUpdate = Repo.GetUserTaskById(id);
                Repo.UpdateUserTaskById(id, value);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public HttpResponseMessage Delete(UserTask _userTask)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                Context.UserTasks.Remove(_userTask);
                Context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}