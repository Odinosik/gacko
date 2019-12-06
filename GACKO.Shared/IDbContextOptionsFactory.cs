using GACKO.DB;
using Microsoft.EntityFrameworkCore;

namespace GACKO.Shared
{
    public interface IDbContextOptionsFactory
    {
        DbContextOptions<GackoDbContext> Get();
    }
}
