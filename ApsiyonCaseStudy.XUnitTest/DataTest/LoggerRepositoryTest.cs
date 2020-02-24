using ApsiyonCaseStudy.Data;
using ApsiyonCaseStudy.Entity.DataContext;
using ApsiyonCaseStudy.Utilies.Abstract;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Xunit;

namespace ApsiyonCaseStudy.XUnitTest.DataTest
{
    public class LoggerRepositoryTest
    {
        DbContextOptions<ApsiyonDBContext> options;
        LoggerRepository _repository = null;
        Mock<ApsiyonDBContext> _dbContext;
        Mock<IFileProcess> _fileProcess;

        public LoggerRepositoryTest()
        {
            _fileProcess = new Mock<IFileProcess>(MockBehavior.Strict);
            options = new DbContextOptionsBuilder<ApsiyonDBContext>().UseInMemoryDatabase(databaseName: "ApsiyonDB").Options;
            _dbContext = new Mock<ApsiyonDBContext>(options);
            _repository = new LoggerRepository(_dbContext.Object, _fileProcess.Object);
        }

        [Fact]
        public void Add_Void_Verify()
        {
            // Arrange
            string message = "TEST";

            // Act
            _repository.Add(message);

            // Assert
            _dbContext.Verify(x => x.SaveChanges());
        }

        [Fact]
        public void Add_Void_Exception()
        {
            // Arrange
            string message = "TEST";
            _dbContext.Setup(x => x.SaveChanges()).Throws(new Exception("Test Exception"));
            _fileProcess.Setup(x => x.Write(It.IsAny<string>())).Verifiable();

            // Act
            _repository.Add(message);

            // Assert
            _fileProcess.Verify(x => x.Write(It.IsAny<string>()), Times.AtLeastOnce);
        }
    }
}
