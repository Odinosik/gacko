using GACKO.Shared.Models.User;
using System.Threading.Tasks;

namespace GACKO.Repositories.User
{
    public interface IUserRepository
    {
        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<int> Create(UserRegisterForm form);
        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserProfile> Get(int id);
        /// <summary>
        /// Update User
        /// </summary>
        /// <returns></returns>
        Task<int> Update();
        /// <summary>
        /// Delete User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> Delete(int id);
    }
}
