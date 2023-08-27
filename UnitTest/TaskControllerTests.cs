using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Trello.Controllers;
using Trello.DataAccess;
using Trello.Interfaces;

namespace Trello.UnitTest
{
    [TestFixture]
    public class TaskControllerTests
    {
        private TaskManagementController _controller;
        private Mock<ApplicationDbContext> _mockDbContext;

        public TaskControllerTests()
        {
            var mockService = new Mock<ITaskService>();
            _mockDbContext = new Mock<ApplicationDbContext>();

            var mockDbSet = new Mock<DbSet<Models.Task>>();
            var task = new Models.Task()
            {
                Id = 2,
                Description = "Create Task",
                Status = "Progress",
                Title = "Contain Data",
                UserId = 437
            };
            mockDbSet.Setup(d => d.Add(task));
            _mockDbContext.Setup(context => context.Tasks)
                .Returns(mockDbSet.Object);
            _controller = new TaskManagementController(_mockDbContext.Object, mockService.Object);
        }

        [Test]
        public void Test_CreateTask_ReturnsOkResult()
        {
            var result = _controller.CreateTask(new Models.Task()
            {
                Id = 1,
                Description = "Create Task",
                Status = "Progress",
                Title = "Contain Data",
                UserId = 437
            });
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Test_GetTask_ReturnsOkResult()
        {
            var result = _controller.GetTask(2);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
