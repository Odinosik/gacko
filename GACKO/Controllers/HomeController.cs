using GACKO.DB.DaoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GACKO.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UserManager<DaoUser> userManager, IHttpContextAccessor contextAccessor) : base(userManager, contextAccessor)
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
