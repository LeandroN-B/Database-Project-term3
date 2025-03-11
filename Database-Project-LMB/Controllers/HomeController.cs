using System.Diagnostics;
using Database_Project_LMB.Models;
using Microsoft.AspNetCore.Mvc;



// TESTING 13:16

namespace Database_Project_LMB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public string Login(string name, string password)
        {
            return $"Name {name} has been sent by {password}";
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public string SendMessage(string message, string name)
        {
            return $"Message {message} has been sent by {name}";
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string GetAllStudents()
        {
            return "Displaying all students";
        }

        
    }
}
