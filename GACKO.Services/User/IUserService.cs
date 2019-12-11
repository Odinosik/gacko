using GACKO.Shared.Models.User;
using System.Threading.Tasks;

namespace GACKO.Services.User
{
    public interface IUserService
    {
        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="userLoginForm"></param>
        /// <returns></returns>
        Task<UserViewModel> LoginUser(UserLoginForm userLoginForm);
        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="userRegisterForm"></param>
        /// <returns></returns>
        Task<UserViewModel> RegisterUser(UserRegisterForm userRegisterForm);
    }
}
