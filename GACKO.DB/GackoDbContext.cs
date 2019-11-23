using GACKO.DB.DaoModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GACKO.DB
{
    public class GackoDbContext : IdentityDbContext<DaoUser, DaoRole, int>
    {
        protected static IConfigurationRoot config;

        public GackoDbContext(DbContextOptions<GackoDbContext> options) : base(options)
        {
            config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: false)
                .Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DaoUser>().ToTable("AspNetUsers");

            base.OnModelCreating(modelBuilder);
        }

        //public virtual DbSet<DaoUser> Users { get; set; }
    }
}
