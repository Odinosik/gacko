using GACKO.DB;
using GACKO.Shared;
using Microsoft.EntityFrameworkCore;

namespace GACKO.Tests
{
    public class DbContextOptionsFactory : IDbContextOptionsFactory
    {
        public DbContextOptions<GackoDbContext> Get()
        {
            var builder = new DbContextOptionsBuilder<GackoDbContext>();
            builder.UseInMemoryDatabase("InMemoryDbForTesting");

            return builder.Options;
        }
    }
}
