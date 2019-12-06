using GACKO.DB;
using GACKO.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GACKO
{
    public class DbContextOptionsFactory : IDbContextOptionsFactory
    {
        public DbContextOptions<GackoDbContext> Get()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile(path: $"appsettings.{Startup.GetEnvironmentVariable()}.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<GackoDbContext>();
            builder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            return builder.Options;
        }
    }
}
