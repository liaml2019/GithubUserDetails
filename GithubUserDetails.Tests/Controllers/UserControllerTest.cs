using GithubUserDetails.Controllers;
using GithubUserDetails.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Test]
        public void Search_Users_Empty_Username()
        {
            var controller = new UserController();
            var user = new User
            {
                UserName = null
            };

            var result = (ViewResult)controller.Search(user);

            Assert.IsTrue(ValidateModel(user).Count > 0);
            Assert.That(ValidateModel(user)[0].ErrorMessage, Is.EqualTo("The UserName field is required."));
            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void Search_Users_Username_Greater_Than_Fifty_Characters()
        {
            var controller = new UserController();
            var user = new User
            {
                UserName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
            };

            var result = (ViewResult)controller.Search(user);

            Assert.IsTrue(ValidateModel(user).Count > 0);
            Assert.That(ValidateModel(user)[0].ErrorMessage, Is.EqualTo("The field UserName must be a string with a maximum length of 50."));
            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void Search_Users_Valid_Username()
        {
            var controller = new UserController();
            var user = new User
            {
                UserName = "robconery"
            };

            var result = (ViewResult)controller.Search(user);

            Assert.IsTrue(ValidateModel(user).Count == 0);
            Assert.That(result.ViewName, Is.EqualTo("Index"));
            Assert.That(result.Model, Is.EqualTo(user));
        }

        //Taken from https://stackoverflow.com/questions/2167811/unit-testing-asp-net-dataannotations-validation
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
