using System;
using System.Collections.Generic;
using System.Linq;
using BangazonTaskTracker.Models;

namespace BangazonTaskTracker.DAL
{
    public class TaskQuery
    {
        readonly IRepository _repository;

        public TaskQuery()
        {
            _repository = new Repository();
        }

        public TaskQuery(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserTask> GetTasksByStatus(TaskStatus status)
        {
            return _repository.Query<UserTask>().Where(x => x.Status == status);
        }

        public void UpdateTask(UserTask task)
        {
            if (task.Status == TaskStatus.Complete && !task.CompletedOn.HasValue)
            {
                task.CompletedOn = DateTime.Now;
            }

            _repository.Upsert(task);
        }
    }
}