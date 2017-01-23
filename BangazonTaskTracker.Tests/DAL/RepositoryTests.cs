using Microsoft.VisualStudio.TestTools.UnitTesting;
using BangazonTaskTracker.Models;
using BangazonTaskTracker.DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Moq;
using System.Linq;
using System.Data.Entity;

namespace BangazonTaskTracker.Tests.DAL
{
    [TestClass]
    public class RepositoryTests
    {
        private Mock<DbSet<UserTask>> mock_tasks { get; set; }
        private Mock<UserTaskContext> mock_context { get; set; }
        private UserTaskRepository repo { get; set; }
        private List<UserTask> _listTasks { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            UserTaskRepository repo = new UserTaskRepository();

            mock_context = new Mock<UserTaskContext>();
            mock_tasks = new Mock<DbSet<UserTask>>();
            repo = new UserTaskRepository(mock_context.Object);
            _listTasks = new List<UserTask>();

            _listTasks = new List<UserTask>()
            {
                new UserTask()
                {
                    Id = 1,
                    Name = "Write Financial Report",
                    Description = "End of Month Reporting",
                    Status = 0
                },

                new UserTask()
                {
                    Id = 2,
                    Name = "Accounts Receivables",
                    Description = "Collect on overdue accounts",
                    Status = 0
                }
            };

            public void ConnectToDatastore()
        {
            var query_tasks = _listTasks.AsQueryable();

            mock_tasks.As<IQueryable<UserTask>>().Setup(m => m.Provider).Returns(query_tasks.Provider);
            mock_tasks.As<IQueryable<UserTask>>().Setup(m => m.Provider).Returns(query_tasks.Expression);
            mock_tasks.As<IQueryable<UserTask>>().Setup(m => m.Provider).Returns(query_tasks.ElementType);
            mock_tasks.As<IQueryable<UserTask>>().Setup(m => m.GetEnumerator()).Returns(() => query_tasks.GetEnumerator());

            mock_context.Setup(c => c.UserTasks).Returns(mock_tasks.Object);
            mock_tasks.Setup(u => u.Add(It.IsAny<UserTask>())).Callback((UserTask t) => mock_tasks.Add(t));


        }
        [TestMethod]
        public void EnsureCanAddUserTask()
        {
            repo.AddUserTask(_userTask);
            //Act
            var _count = repo.UserTasks.Count();
            var expectedCount = 1;
            //Assert
            Assert.Equals(_count, 1);
        }
        [TestMethod]
        public void EnsureICanCreateInstanceOfUserTask()
        {
            //Arrange Act
            UserTask _task = new UserTask();
            //Assert
            Assert.IsNotNull(_task);
        }
    }
}
