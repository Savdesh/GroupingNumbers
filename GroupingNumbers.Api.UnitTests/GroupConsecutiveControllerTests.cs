using System;
using System.Linq;
using GroupingNumbers.Api.Controllers;
using GroupingNumbers.Services.src.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace GroupingNumbers.Api.UnitTests
{
    [TestFixture]
    public class GroupConsecutiveControllerTests
    {
        [Test]
        public void Test_Post_WhenCalled_InvokesTheService()
        {
            // Arrange
            int[] valuesForTest = { 1, 2, 3 };
            var groupConsecutivesMock = new Mock<IGroupConsecutives>();
            groupConsecutivesMock.Setup(x => x.Group(valuesForTest)).Returns("1-3;");

            var controller = new GroupConsecutiveController(groupConsecutivesMock.Object);

            // Act
            controller.Post(valuesForTest.ToList());         

            // Assert
            groupConsecutivesMock.VerifyAll();
        }

        [Test]
        public void Test_Post_WhenCalledWithValidInput_ReturnsResult()
        {
            // Arrange
            int[] valuesForTest = { 1, 2, 3 };
            var groupConsecutivesMock = new Mock<IGroupConsecutives>();
            groupConsecutivesMock.Setup(x => x.Group(valuesForTest)).Returns("1-3;");

            var controller = new GroupConsecutiveController(groupConsecutivesMock.Object);

            // Act
            ActionResult<string> result = controller.Post(valuesForTest.ToList());

            // Assert
            Assert.That(result.Value, Is.EqualTo("1-3;"));
        }


        [Test]
        public void Test_Post_WhenCalledWithInValidInput_ReturnsBadRequest()
        {
            // Arrange
            var groupConsecutivesMock = new Mock<IGroupConsecutives>();
            groupConsecutivesMock.Setup(x => x.Group(null)).Throws(new ArgumentNullException());

            var controller = new GroupConsecutiveController(groupConsecutivesMock.Object);

            // Act
            ActionResult<string> result = controller.Post(null);

            // Assert
            BadRequestObjectResult badRequestObjectResult = result.Result as BadRequestObjectResult;
            Assert.NotNull(badRequestObjectResult);            
        }
    }
}
