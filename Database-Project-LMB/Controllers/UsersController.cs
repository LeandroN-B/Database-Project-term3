using Microsoft.AspNetCore.Mvc;

namespace Database_Project_LMB.Controllers
{
        public class UsersController : Controller
        {
            public IActionResult Index()
            {
                List<User> users =
                    [
                    new User(1, "Peter Sauber", "06-123456", "pete@sauber@gmail.com"),
                    new User(2, "Bill Hodges", "06-44556677", "bill@hodges@gmail.com"),
                    new User(3, "Morris Belamy", "06-11228899", "morris@belamy@gmail.com")
                    ];
                return View(users);
            }
        }
    }
