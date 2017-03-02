using BangazonTaskTracker.DAL;
using BangazonTaskTracker.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BangazonTaskTracker.Controllers
{
    public class UserTaskController : ApiController
    {
        readonly Repository _repo = new Repository();
        readonly TaskQuery _query = new TaskQuery();

        /* GET api/<controller>  This Get() will return a 
        list of all tasks, taking no arguments, and return 
        an error if there are no tasks in the database.
        */
        public HttpResponseMessage Get()
        {
            var listy = _repo.Query<UserTask>().ToList();

            if (listy.Any())
            {
               return Request.CreateResponse(listy);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        /* GET api/<controller>/5  This Get() will return a 
        specific task taking argument userTaskId, and returning
        an error if it is not found in the database.
        */
        public HttpResponseMessage Get(int userTaskId)
        {
            var specificTask = _repo.GetById<UserTask>(userTaskId);
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
        [HttpPost]
        public HttpResponseMessage Post(UserTask userTask)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _repo.Insert(userTask);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        /*PUT api/<controller>/5  This Put() will update a 
         task  taking argument id and value, and return an 
         error if it is not found in the database.
        */
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]UserTask value)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _query.UpdateTask(value);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        /* DELETE api/<controller>/5  This Delete() will delete a 
            task from the database taking argument _userTask.
        */
        [HttpDelete]
        
        public HttpResponseMessage Delete(int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nothing to delete");

            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _repo.Delete<UserTask>(id);
            return Request.CreateResponse(HttpStatusCode.Found, ModelState);
        }
    }
}