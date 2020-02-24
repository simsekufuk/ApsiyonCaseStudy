using ApsiyonCaseStudy.Data.Abstract;
using ApsiyonCaseStudy.Entity.DataContext;
using ApsiyonCaseStudy.Entity.DataModels;
using ApsiyonCaseStudy.Utilies.Abstract;
using System;

namespace ApsiyonCaseStudy.Data
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly ApsiyonDBContext _dbContext;
        private readonly IFileProcess _fileProcess;

        public LoggerRepository(ApsiyonDBContext dbContext, IFileProcess fileProcess)
        {
            _dbContext = dbContext;
            _fileProcess = fileProcess;
        }

        public void Add(string message)
        {
            try
            {
                _dbContext.tblLog.Add(new Log { Message = message, CreateDate = DateTime.Now });
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _fileProcess.Write("LoggerRepository - Add - Message : " + message + " - Exception Message : " + ex.Message);
            }
        }
    }
}
