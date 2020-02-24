using ApsiyonCaseStudy.Business.Abstract;
using ApsiyonCaseStudy.Web.Controllers;
using ApsiyonCaseStudy.Web.Models;
using ApsiyonCaseStudy.XUnitTest.ModelTest;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ApsiyonCaseStudy.XUnitTest.ControllerTest
{
    public class LoggerControllerTest
    {
        LoggerController _controller = null;
        Mock<ILoggerManager> _manager;

        public LoggerControllerTest()
        {
            _manager = new Mock<ILoggerManager>(MockBehavior.Strict);
            _controller = new LoggerController(_manager.Object);
        }

        [Fact]
        public void Add_Get_ReturnView()
        {
            // Arrange


            // Act
            var result = _controller.Add();

            // Assert
            Assert.IsAssignableFrom<ActionResult>(result);
        }

        [Fact]
        public void Add_Post_ModelStateInvalid_ReturnView()
        {
            // Arrange
            LoggerViewModel loggerViewModel = new LoggerViewModel
            {
                Message = null,
                ObjectModel = null
            };

            _controller.ModelState.AddModelError("Message", "Required");

            // Act
            var result = _controller.Add(loggerViewModel);

            // Assert
            Assert.IsAssignableFrom<ActionResult>(result);
        }

        [Fact]
        public void Add_Post_ModelStateValid_RedirectToAction()
        {
            // Arrange

            LoggerViewModel loggerViewModel = new LoggerViewModel()
            {
                Message = "TEST",
                ObjectModel = new ObjectTestModel { Type = "Add" }
            };

            _manager.Setup(x => x.Add(loggerViewModel.Message, loggerViewModel.ObjectModel)).Verifiable();

            // Act
            var result = _controller.Add(loggerViewModel);

            // Assert
            Assert.IsAssignableFrom<RedirectToActionResult>(result);
            _manager.Verify();

            var redirectToAction = (RedirectToActionResult)result;
            Assert.Equal("Add", redirectToAction.ActionName);
        }
    }
}
