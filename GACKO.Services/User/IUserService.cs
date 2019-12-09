using GACKO.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GACKO.Services.User
{
    public interface IUserService
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
