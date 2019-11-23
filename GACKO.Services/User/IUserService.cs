using GACKO.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GACKO.Services.User
{
    public interface IUserService
    {
        Task<int> Create(UserRegisterForm form);
        Task<UserProfile> Get(int id);
        Task<int> Update();
        Task<int> Delete(int id);
    }
}
