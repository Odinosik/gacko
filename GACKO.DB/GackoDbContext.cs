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
           
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DaoBankAccount>().ToTable("BankAccount");
            modelBuilder.Entity<DaoVirtualAccount>().ToTable("VirtualAccount");
            modelBuilder.Entity<DaoExpense>().ToTable("Expense");
            modelBuilder.Entity<DaoExpenseCategory>().ToTable("ExpenseCategory");
            modelBuilder.Entity<DaoSalesDocument>().ToTable("SalesDocument");
        }

        public virtual DbSet<DaoBankAccount> BankAccounts { get; set; }
        public virtual DbSet<DaoVirtualAccount> VirtualAccounts { get; set; }
        public virtual DbSet<DaoExpense> Expenses { get; set; }
        public virtual DbSet<DaoExpenseCategory> ExpenseCategories { get; set; }
        public virtual DbSet<DaoSalesDocument> SalesDocuments { get; set; }

    }
}
