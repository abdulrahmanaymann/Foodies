using Foodies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Foodies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CustomerView()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult UserSignUp()
        {
            return View();
        }
        public IActionResult AdminSignUp()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        public IActionResult start()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
