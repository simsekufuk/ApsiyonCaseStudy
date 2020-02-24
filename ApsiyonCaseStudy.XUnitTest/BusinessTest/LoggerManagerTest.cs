using ApsiyonCaseStudy.Business;
using ApsiyonCaseStudy.Data.Abstract;
using ApsiyonCaseStudy.Utilies.Abstract;
using ApsiyonCaseStudy.XUnitTest.ModelTest;
using Moq;
using System;
using Xunit;

namespace ApsiyonCaseStudy.XUnitTest.BusinessTest
{
    public class LoggerManagerTest
    {
        LoggerManager _manager = null;
        Mock<ILoggerRepository> _repository;
        Mock<IFileProcess> _fileProcess;

        public LoggerManagerTest()
        {
            _fileProcess = new Mock<IFileProcess>(MockBehavior.Strict);
            _repository = new Mock<ILoggerRepository>(MockBehavior.Strict);
            _manager = new LoggerManager(_repository.Object, _fileProcess.Object);
        }

        [Fact]
        public void Add_Void_Verify()
        {
            // Arrange
            string message = "TEST";
            ObjectTestModel objectTestModel = new ObjectTestModel
            {
                Type = "Add"
            };
            _repository.Setup(x => x.Add(It.IsAny<string>())).Verifiable();

            // Act
            _manager.Add(message, objectTestModel);

            // Assert
            _repository.Verify(x => x.Add(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Add_Void_Exception()
        {
            // Arrange
            string message = "TEST";
            ObjectTestModel objectTestModel = new ObjectTestModel
            {
                Type = "Add"
            };

            _repository.Setup(x => x.Add(It.IsAny<string>())).Throws(new Exception("Test Exception"));
            _fileProcess.Setup(x => x.Write(It.IsAny<string>())).Verifiable();

            // Act
            _manager.Add(message, objectTestModel);

            // Assert
            _fileProcess.Verify(x => x.Write(It.IsAny<string>()), Times.AtLeastOnce);
        }
    }
}
