using GACKO.Shared.Models.User;
using System.Threading.Tasks;

namespace GACKO.Repositories.User
{
    public interface IUserRepository
    {
        Task<int> Create(UserRegisterForm form);
        Task<UserProfile> Get(int id);
        Task<int> Update();
        Task<int> Delete(int id);
    }
}
