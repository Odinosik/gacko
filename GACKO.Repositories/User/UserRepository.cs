using System.Threading.Tasks;
using AutoMapper;
using GACKO.DB;
using GACKO.Shared.Models.User;
using Microsoft.EntityFrameworkCore;

namespace GACKO.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private GackoDbContext _context;

        public UserRepository(IMapper mapper)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GackoDbContext>();
            _context = new GackoDbContext(optionsBuilder.Options);
        }

        public Task<int> Create(UserRegisterForm form)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserProfile> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
