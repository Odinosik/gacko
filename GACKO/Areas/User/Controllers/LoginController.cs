using AutoMapper;
using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Shared;
using GACKO.Shared.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GACKO.Areas.User.Controllers
{
    [Area("User")]
    public class LoginController : GackoBaseController
    {
        private readonly UserManager<DaoUser> _userManager = null;
        private readonly SignInManager<DaoUser> _signInManager = null;
        private IMapper _mapper;

        public LoginController(UserManager<DaoUser> userManager,
            SignInManager<DaoUser> signInManager,
            IHttpContextAccessor contextAccessor, IMapper mapper) : base(userManager, contextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }


        /// <summary>
        /// Login Main Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Index()
        {
            return View("Login");
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
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
                UserContext.UserId = user.Id;
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

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterForm userModel, string password)
        {
            var user = _userManager.FindByNameAsync(userModel.UserName).Result;
            if (user != null)
            {
                userModel.RegisterErrorMessage = "Username is in use";
                return View("Login");
            }
            user = _userManager.FindByEmailAsync(userModel.UserName).Result;
            if (user != null)
            {
                userModel.RegisterErrorMessage = "Email is in use";
                return View("Login");
            }
            var registerUser = _mapper.Map<DaoUser>(userModel);
            await _userManager.CreateAsync(registerUser, userModel.Password);
            var Checkuser = _userManager.FindByNameAsync(userModel.UserName).Result;
            return View("Login");
        }

        /// <summary>
        /// Logout user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }
    }
}