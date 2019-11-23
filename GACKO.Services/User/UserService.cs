using GACKO.Repositories.User;
using GACKO.Shared.Models.User;
using System.Threading.Tasks;

namespace GACKO.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<int> Create(UserRegisterForm form)
        {
            return _userRepository.Create(form);
        }

        public Task<UserProfile> Get(int id)
        {
            return _userRepository.Get(id);
        }

        public Task<int> Update()
        {
            return _userRepository.Update();
        }

        public Task<int> Delete(int id)
        {
            return _userRepository.Delete(id);
        }
    }
}
