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
    [Route ("Task")]
    public class UserTaskController : ApiController
    {
        UserTaskRepository Repo = new UserTaskRepository();
        UserTaskContext Context { get; set; }

        /* GET api/<controller>  This Get() will return a 
        list of all tasks, taking no arguments, and return 
        an error if there are no tasks in the database.
        */
        public HttpResponseMessage Get()
        {
            var listy = Repo.ListOfTasks;

            if (listy != null)
            {
               return Request.CreateResponse(listy);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        /* GET api/<controller>/5  This Get() will return a 
        specific task taking argument userTaskId, and returning
        an error if it is not found in the database.
        */
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

        /* POST api/<controller>  This Post() will post a task
             in the database taking argument userTask.
        */
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

        /*PUT api/<controller>/5  This Put() will update a 
         task  taking argument id and value, and return an 
         error if it is not found in the database.
        */
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

        /* DELETE api/<controller>/5  This Delete() will delete a 
            task from the database taking argument _userTask.
        */
        [HttpDelete]
        public HttpResponseMessage Delete(UserTask _userTask)
        {
            if (_userTask == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nothing to delete");

            } else
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
}