using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BangazonTaskTracker.Models;
using BangazonTaskTracker.DAL;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace BangazonTaskTracker.Tests.DAL
{
    [TestClass]
    public class UserTaskQueryTests
    {
        Mock<IRepository> _mockRepository;

        [TestInitialize]
        public void Initialize()
        {   
            _mockRepository = new Mock<IRepository>();
            _mockRepository.Setup(x => x.Query<UserTask>()).Returns(
                new List<UserTask>()
                {
                    new UserTask()
                    {
                        Id = 1,
                        Name = "Write Financial Report",
                        Description = "End of Month Reporting",
                        Status = TaskStatus.ToDo
                    },

                    new UserTask()
                    {
                        Id = 2,
                        Name = "Accounts Receivables",
                        Description = "Collect on overdue accounts",
                        Status = TaskStatus.InProgress
                    },

                    new UserTask()
                    {
                        Id = 2,
                        Name = "Accounts Receivables",
                        Description = "Collect on overdue accounts",
                        Status = TaskStatus.InProgress
                    }
                }.AsQueryable());
        }

        [TestMethod]
        public void EnsureCanGetTaskByStatus()
        {
            //Arrange
            var query = new TaskQuery(_mockRepository.Object);
            //Act
            var result = query.GetTasksByStatus(TaskStatus.InProgress);
            //Assert
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void CompletedTasksWithoutCompletedDatesShouldHaveCompletedDatesSet()
        {
            //Arrange
            var query = new TaskQuery(_mockRepository.Object);
            var task = new UserTask {Id = 2, Status = TaskStatus.Complete};
            //Act
            query.UpdateTask(task);
            //Assert
            Assert.IsTrue(task.CompletedOn.HasValue);
            _mockRepository.Verify(x => x.Upsert(task));
        }

        [TestMethod]
        public void CompletedTasksWithCompletedDatesShouldNotHaveCompletedDatesReset()
        {
            //Arrange
            var query = new TaskQuery(_mockRepository.Object);
            var completedOn = DateTime.Parse("1/1/2001");
            var task = new UserTask {Id = 2, Status = TaskStatus.Complete, CompletedOn = completedOn};
            //Act
            query.UpdateTask(task);
            //Assert
            Assert.AreEqual(completedOn, task.CompletedOn);
        }
    }
}
