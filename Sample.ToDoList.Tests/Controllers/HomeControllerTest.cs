using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Sample.ToDoList.Controllers;
using Sample.ToDoList.Models;
using Sample.ToDoList.Repository;
using Sample.ToDoList.Service;
using System.Web.Mvc;

namespace Sample.ToDoList.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private Mock<UserService> _userService;
        private HomeController _controller;

        [SetUp]
        public void Setup()
        {
            _userService = new Mock<UserService>();
            _controller = new HomeController(_userService.Object);
        }

        [TestMethod]
        public void Index()
        {
            // Act
            ViewResult result = _controller.Index() as ViewResult;

            // Assert
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void Login()
        {
            // Arrange
            User userObj = null;
            _userService.Setup(x => x.GetUser(It.IsAny<string>(), It.IsAny<string>())).Returns(userObj);

            // Act
            ViewResult result = _controller.Login(new ViewModels.UserViewModel()) as ViewResult;

            // Assert
            result.Should().NotBeNull();
        }
    }
}
