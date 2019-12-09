using AutoMapper;
using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.User;
using GACKO.Shared;
using GACKO.Shared.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GACKO.Areas.User.Controllers
{
    [Area("User")]
    public class LoginController : BaseController
    {
        private readonly UserManager<DaoUser> _userManager = null;
        private readonly SignInManager<DaoUser> _signInManager = null;
        private readonly IUserService _usersService = null;
        private readonly IMapper _mapper;

        public LoginController(UserManager<DaoUser> userManager,
            SignInManager<DaoUser> signInManager,
            IUserService usersService,
            IMapper mapper,
            IHttpContextAccessor contextAccessor) : base(userManager, contextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usersService = usersService;
            _mapper = mapper;
        }


        //
        // GET: /Login/
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authorize(UserLoginForm userModel)
        {

            var user = _userManager.FindByNameAsync(userModel.Username).Result ?? _userManager.FindByEmailAsync(userModel.Username).Result;
            if (user == null)
            {
                userModel.LoginErrorMessage = "Wrong username or password.";
                return View("Login", userModel);
            }

            var result = await _signInManager.PasswordSignInAsync(userModel.Username,
                           userModel.Password, false, false);
            if (result.Succeeded)
            {
                UserContext.UserId =  user.Id;
                return RedirectToAction("Index", "BankAccount", new { area = "BankAccount" });
            }
            if (result.IsLockedOut)
            {
                userModel.LoginErrorMessage = "User account locked out.";
                return View("Login", userModel);
            }
            else
            {
                userModel.LoginErrorMessage = "Wrong username or password.";
                return View("Login", userModel);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserLoginForm userModel)
        {
            //var result = _userManager.CreateAsync();
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }
    }
}