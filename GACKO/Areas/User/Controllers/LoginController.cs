using AutoMapper;
using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.User;
using GACKO.Shared.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            IMapper mapper)
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
            var result = await _signInManager.PasswordSignInAsync(userModel.Username,
                           userModel.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToHome("Privacy");
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

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }
    }
}