using GACKO.DB.DaoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GACKO.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UserManager<DaoUser> userManager, ILogger<HomeController> logger) : base(userManager)
        {
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }
    }
}
