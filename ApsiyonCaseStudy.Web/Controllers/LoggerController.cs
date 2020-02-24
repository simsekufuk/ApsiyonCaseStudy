using ApsiyonCaseStudy.Business.Abstract;
using ApsiyonCaseStudy.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApsiyonCaseStudy.Web.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILoggerManager _loggerManager;

        public LoggerController(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(LoggerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _loggerManager.Add(viewModel.Message, viewModel.ObjectModel);

                return RedirectToAction("Add");
            }
            else
            {
                return View(viewModel);
            }
        }
    }
}