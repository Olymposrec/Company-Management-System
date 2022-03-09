using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.Controllers
{
    public class HomeController:Controller
    {
        private readonly INotyfService _notyf;
        private readonly ILogger<HomeController> _logger;
        public HomeController(INotyfService notyf, ILogger<HomeController> logger)
        {
            _notyf = notyf;
            _logger = logger;
        }
        public IActionResult Index()
        {
            _notyf.Custom("Welcome To Company App.",5, "salmon", "fab fa-app-store-ios");
            return View();
        }
    }
}
