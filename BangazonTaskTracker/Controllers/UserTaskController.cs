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

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public UserTask Get(int id)
        {
            return Repo.GetUserTaskById(id);
        }

        // POST api/<controller>
        public void Post([FromBody]UserTask _userTask)
        {
            Repo.AddUserTask(_userTask);
            //this is not completed left here only for build purposes
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}