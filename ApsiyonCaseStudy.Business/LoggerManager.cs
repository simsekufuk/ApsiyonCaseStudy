using ApsiyonCaseStudy.Business.Abstract;
using ApsiyonCaseStudy.Data.Abstract;
using ApsiyonCaseStudy.Utilies.Abstract;
using Newtonsoft.Json;
using System;

namespace ApsiyonCaseStudy.Business
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILoggerRepository _loggerRepository;
        private readonly IFileProcess _fileProcess;

        public LoggerManager(ILoggerRepository ILoggerRepository, IFileProcess fileProcess)
        {
            _loggerRepository = ILoggerRepository;
            _fileProcess = fileProcess;
        }

        public void Add(string message, object obj)
        {
            try
            {
                if (!string.IsNullOrEmpty(message))
                {
                    if (obj != null)
                    {
                        string responseJson = JsonConvert.SerializeObject(obj);

                        message += " - " + responseJson;
                    }

                    _loggerRepository.Add(message);
                }
            }
            catch (Exception ex)
            {
                _fileProcess.Write("LoggerManager - Add - Exception Message : " + ex.Message);
            }

        }
    }
}
