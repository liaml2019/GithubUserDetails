using GithubUserDetails.Controllers;
using NUnit.Framework;
using System;
using System.Web.Mvc;

namespace GithubUserDetails.Tests.Controllers
{
    [TestFixture()]
    public class UserControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = (ViewResult)controller.Index();

            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }
    }
}
