using AutoMapper;
using GACKO.DB.DaoModels;
using GACKO.Shared.Models;
using GACKO.Shared.Models.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using GACKO.Shared;
using Microsoft.EntityFrameworkCore;

namespace GACKO.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<DaoUser> _userManager;
        private readonly SignInManager<DaoUser> _signInManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<DaoUser> userManager,
            SignInManager<DaoUser> signInManager,
        IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<UserViewModel> LoginUser(UserLoginForm userLoginForm)
        {
            var viewModel = new UserViewModel()
            {
                UserloginForm = new UserLoginForm()
                {
                    Username = userLoginForm.Username
                }
            };
            try
            {
                var user = await _userManager.FindByNameAsync(userLoginForm.Username) ?? await _userManager.FindByEmailAsync(userLoginForm.Username);
                if (user == null)
                {
                    viewModel.Error = new GackoError("Could not find account with given username.");
                }

                var result = await _signInManager.PasswordSignInAsync(userLoginForm.Username,
                    userLoginForm.Password, false, false);
                if (result.Succeeded)
                {
                    UserContext.UserId = user.Id;
                    viewModel.IsSuccess = true;
                }
                else if (result.IsLockedOut)
                {
                    viewModel.Error = new GackoError("User account locked out.");
                }
                else if (result.IsNotAllowed)
                {
                    viewModel.Error = new GackoError("Insufficient permissions.");
                }
                else
                {
                    viewModel.Error = new GackoError("Wrong username or password.");
                }
            }
            catch (Exception e)
            {
                viewModel.Error = new Shared.Models.GackoError(e);
            }
            return viewModel;
        }

        public async Task<UserViewModel> RegisterUser(UserRegisterForm userRegisterForm)
        {
            var viewModel = new UserViewModel()
            {
                UserloginForm = new UserLoginForm()
                {
                    Username = userRegisterForm.UserName
                }
            };
            try
            {
                var user = _userManager.FindByNameAsync(userRegisterForm.UserName).Result;
                if (user != null)
                {
                    viewModel.Error = new GackoError("Username is in use");
                    return viewModel;
                }

                user = _userManager.FindByEmailAsync(userRegisterForm.Email).Result;
                if (user != null)
                {
                    viewModel.Error = new GackoError("Email is in use");
                    return viewModel;
                }

                var registerUser = _mapper.Map<DaoUser>(userRegisterForm);

                var userId = await _userManager.Users.Select(_ => _.Id).OrderByDescending(_ => _).FirstOrDefaultAsync();
                registerUser.Id = userId + 1;
                registerUser.EmailConfirmed = true;

                var result = await _userManager.CreateAsync(registerUser, userRegisterForm.Password);
                if (result.Succeeded)
                {
                    var checkuser = await _userManager.FindByNameAsync(userRegisterForm.UserName);
                    if (checkuser != null)
                    {
                        await _userManager.AddToRoleAsync(registerUser, "Administrator");
                        viewModel.UserloginForm = new UserLoginForm()
                        {
                            Username = checkuser.UserName
                        };
                        viewModel.IsSuccess = true;
                        viewModel.Success = new GackoSuccess("Registration succeeded.");
                    }
                }
                else
                {
                    viewModel.Error = new GackoError("Rgistration failed.");
                }
            }
            catch (Exception e)
            {
                viewModel.Error = new Shared.Models.GackoError(e);
            }
            return viewModel;
        }
    }
}
